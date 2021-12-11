using KorkiDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;

namespace KorkiDataAccessLib.Access
{
    public class UserReader
    {
        private readonly ISQLAccess _access;

        public UserReader(ISQLAccess access)
        {
            _access = access;
        }

        public UserData GetUser(int id)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                string sql = "SELECT * FROM dbo.User WHERE ID = @ID";
                return conn.QueryFirst<UserData>(sql, new { ID = id });
            }
        }

        public UserData GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserData GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
