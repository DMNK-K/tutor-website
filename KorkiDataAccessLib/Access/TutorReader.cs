using KorkiDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using KorkiDataAccessLib.Utility;

namespace KorkiDataAccessLib.Access
{
    public class TutorReader : ITutorReader
    {
        private readonly ISQLAccess _access;

        public TutorReader(ISQLAccess access)
        {
            _access = access;
        }

        public List<Tutor> GetAllWorkingTutors()
        {
            List<Tutor> res;
            using (IDbConnection conn = _access.GetConnection())
            {
                //return new List<Tutor>(conn.Query<Tutor>("EXEC spGetAllWorkingTutors"));
                res = conn.Query<Tutor, City, Tutor>(DapperQueries.GetAllWorkingTutors, (t, c) => { t.City = c; return t; }, splitOn: DapperQueries.TutorCitySplitOn).ToList();
            }
            return res;
        }

        public List<Tutor> GetTutorsFiltered(TutorFilters filter)
        {
            //some filtering for basic search happens in SQL, some via LINQ, to prefilter and reduce
            //amount of results in the reseult set
            //it ould be nice to use a stored procedure, but dapper needs to map retrieved values
            //to properties correctly, and to do that i need to specify some things inside the app
            List<Tutor> res = new List<Tutor>();
            using (IDbConnection conn = _access.GetConnection())
            {
                string sql = GetSQLForTutorFilter(filter.IsAdvanced, filter.NameStr);
                res = conn.Query<Tutor, City, Tutor>(sql, (t, c) => { t.City = c; return t; }, filter, splitOn: DapperQueries.TutorCitySplitOn).ToList();
            }
            FilterTutorsByLvl(res, filter);
            return res;
        }

        private string GetSQLForTutorFilter(bool isAdvanced, string nameStr)
        {
            if (string.IsNullOrWhiteSpace(nameStr))
            {
                return (isAdvanced) ? DapperQueries.TutorSearchAdvNoNameStr : DapperQueries.TutorSearchSimpleNoNameStr;
            }
            else
            {
                return (isAdvanced) ? DapperQueries.TutorSearchAdv : DapperQueries.TutorSearchSimple;
            }
        }

        /// <summary>
        /// Eliminates Tutors that don't teach anything at a level specified at filter. If
        /// the filter.NameStr is found among tought subjects, also eliminates a Tutor if that one subject
        /// is not thought at the specified level.
        /// </summary>
        public void FilterTutorsByLvl(List<Tutor> list, TutorFilters filter)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                string nameStrLower = filter.NameStr.ToLower();
                if (list[i].TeachesSubject(nameStrLower))
                {
                    if (!list[i].Subjects[nameStrLower].Contains(filter.Lvl))
                    {
                        list.RemoveAt(i);
                    }
                }
                else if (!list[i].TeachesAnySubjectAtLvl(filter.Lvl))
                {
                    list.RemoveAt(i);
                }
            }
        }

        public Tutor GetTutor(int id)
        {
            Tutor t;
            using (IDbConnection conn = _access.GetConnection())
            {
                var paramsT = new { ID = id };
                string sql = "SELECT * FROM dbo.Tutor WHERE ID = @ID";
                t = conn.QueryFirst<Tutor>(sql, paramsT);

                sql = "SELECT * FROM dbo.City WHERE ID = @CityID";
                var paramsC = new { CityID = t.CityID };
                City c = conn.QueryFirst<City>(sql, paramsC);

                t.City = c;
            }
            return t;
        }
    }
}
