using KorkiDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Data.SqlClient;

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

        //public static List<Tutor> GetTutorsFiltered(TutorFiltersBasic filter)
        //{

        //}

        //public static List<Tutor> GetTutorsFiltered(TutorFiltersBasic filter, TutorFiltersAdv advFilter)
        //{

        //}
    }
}
