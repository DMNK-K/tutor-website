using KorkiDataAccessLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace KorkiDataAccessLib.Access
{
    public class UserReader : IUserReader
    {
        private readonly ISQLAccess _access;

        public UserReader(ISQLAccess access)
        {
            _access = access;
        }

        public async Task<UserData> GetUser(int id)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                string sql = "SELECT * FROM dbo.User WHERE ID = @ID";
                return await conn.QueryFirstOrDefaultAsync<UserData>(sql, new { ID = id });
            }
        }

        public async Task<UserData> GetUserByEmail(string email)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                string sql = "SELECT * FROM dbo.User WHERE Email = @Email";
                return await conn.QueryFirstOrDefaultAsync<UserData>(sql, new { Email = email });
            }
        }

        public async Task<UserData> GetUserByUsername(string username)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                string sql = "SELECT * FROM dbo.User WHERE Username = @Username";
                return await conn.QueryFirstOrDefaultAsync<UserData>(sql, new { Username = username });
            }
        }
    }
}
