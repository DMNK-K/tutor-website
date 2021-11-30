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
    public static class TutorAccess
    {
        public static List<Tutor> GetAllWorkingTutors()
        {
            using (IDbConnection conn = new SqlConnection(SQLAccess.KorkiConnectionStr))
            {
                return new List<Tutor>(conn.Query<Tutor>("EXEC spGetAllWorkingTutors"));
            }
        }

        public static List<Tutor> GetTutorsFiltered(TutorFiltersBasic filter)
        {
            //some filtering for basic search happens in SQL, some via LINQ, to prefilter and reduce
            //amount of results in the reseult set
            //it ould be nice to use a stored procedure, but dapper needs to map retrieved values
            //to properties correctly, and to do that i need to specify some things inside the app

            List<Tutor> res;
            using (IDbConnection conn = new SqlConnection(SQLAccess.KorkiConnectionStr))
            {
                string sql;
                if (string.IsNullOrWhiteSpace(filter.NameStr))
                {
                    sql = DapperQueries.TutorSearchSimple;
                }
                else
                {
                    sql = DapperQueries.TutorSearchSimpleNoNameStr;
                }
                res = conn.Query<Tutor, City, Tutor>(sql, (t, c) => { t.City = c; return t; }, filter).ToList();
            }
            FilterTutorsByLvl(res, filter);
            return res;
        }

        public static List<Tutor> GetTutorsFiltered(TutorFiltersBasic filter, TutorFiltersAdv advFilter)
        {
            List<Tutor> res = new List<Tutor>();
            using (IDbConnection conn = new SqlConnection(SQLAccess.KorkiConnectionStr))
            {
                string sql;

            }
            FilterTutorsByLvl(res, filter);
            return res;
        }

        /// <summary>
        /// Eliminates Tutors that don't teach anything at a level specified at filter. If
        /// the filter.NameStr is found among tought subjects, also eliminates a Tutor if that one subject
        /// is not thought at the specified level.
        /// </summary>
        public static void FilterTutorsByLvl(List<Tutor> list, TutorFiltersBasic filter)
        {
            for (int i = list.Count; i >= 0; i--)
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

        public static Tutor GetTutor(int id)
        {
            Tutor t;
            using (IDbConnection conn = new SqlConnection(SQLAccess.KorkiConnectionStr))
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

        //public static void CreateTutor(Tutor tutor)
        //{
        //    using (IDbConnection conn = new SqlConnection(SQLAccess.KorkiConnectionStr))
        //    {
        //        string sql = "";
        //        conn.Execute();
        //    }
        //}
    }
}
