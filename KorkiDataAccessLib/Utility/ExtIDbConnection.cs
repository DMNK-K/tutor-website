using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;


namespace KorkiDataAccessLib.Utility
{
    public static class ExtIDbConnection
    {
        public static async Task<int> ExecuteStoredAsync(this IDbConnection conn, string storedProcName, object param = null)
        {
            return await conn.ExecuteAsync(storedProcName, param, commandType: CommandType.StoredProcedure);
        }

        public static int ExecuteStored(this IDbConnection conn, string storedProcName, object param = null)
        {
            return conn.Execute(storedProcName, param, commandType: CommandType.StoredProcedure);
        }
    }
}
