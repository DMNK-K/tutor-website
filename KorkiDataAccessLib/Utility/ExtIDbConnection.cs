using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;


namespace KorkiDataAccessLib.Utility
{
    public static class ExtIDbConnection
    {
        public static int ExecuteStored(this IDbConnection conn, string storedProcName, object param = null)
        {
            return conn.Execute(storedProcName, param, commandType: CommandType.StoredProcedure);
        }
    }
}
