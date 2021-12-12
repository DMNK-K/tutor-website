using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using KorkiDataAccessLib.Models;
using KorkiDataAccessLib.Utility;

namespace KorkiDataAccessLib.Access
{
    public class UserWriter : IUserWriter
    {
        private readonly ISQLAccess _access;

        public UserWriter(ISQLAccess access)
        {
            _access = access;
        }

        public async Task<int> CreateUser(UserData userData)
        {
            if (userData == null) { return 0; }
            using (IDbConnection conn = _access.GetConnection())
            {
                return await conn.ExecuteStoredAsync("spUserCreate", userData);
            }
        }

        public async Task<int> CreateUserWithTutor(UserData userData, string nameFirst, string nameLast, int cityID)
        {
            if (userData == null) { return 0; }
            using (IDbConnection conn = _access.GetConnection())
            {
                DynamicParameters param = new DynamicParameters(userData);
                param.Add("@NameFirst", nameFirst);
                param.Add("@NameLast", nameLast);
                param.Add("@CityID", cityID);
                return await conn.ExecuteStoredAsync("spUserTutorCreate", param);
            }
        }

        public async Task<int> DeleteUser(int id, string deletionInfo)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                var param = new { ID = id, DeletionInfo = deletionInfo };
                return await conn.ExecuteStoredAsync("spUserDelete", param);
            }
        }

        public async Task<int> UpdateUser(UserData userData)
        {
            if (userData == null) { return 0; }
            using (IDbConnection conn = _access.GetConnection())
            {
                return await conn.ExecuteStoredAsync("spUserUpdate", userData);
            }
        }

        //public async Task<int> SetEmail(int id, string email)
        //{
        //    using (IDbConnection conn = _access.GetConnection())
        //    {
        //        var param = new {ID = id, Email = email };
        //        return await conn.ExecuteAsync("UPDATE dbo.User SET Email = @Email WHERE ID = @ID", param);
        //    }
        //}

        //public async Task<int> SetUsername(int id, string username)
        //{
        //    using (IDbConnection conn = _access.GetConnection())
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //public async Task<int> SetPasswordHash(int id, string hash)
        //{
        //    using (IDbConnection conn = _access.GetConnection())
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
