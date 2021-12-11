using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using KorkiDataAccessLib.Models;
using KorkiDataAccessLib.Utility;

namespace KorkiDataAccessLib.Access
{
    public class UserWriter
    {
        private readonly ISQLAccess _access;

        public UserWriter(ISQLAccess access)
        {
            _access = access;
        }

        public void CreateUser(UserData userData)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                conn.ExecuteStored("spUserCreate", userData);
            }
        }

        public void CreateUserWithTutor(UserData userData, string nameFirst, string nameLast, int cityID)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                DynamicParameters param = new DynamicParameters(userData);
                param.Add("@NameFirst", nameFirst);
                param.Add("@NameLast", nameLast);
                param.Add("@CityID", cityID);
                conn.ExecuteStored("spUserTutorCreate", param);
            }
        }

        public void DeleteUser(int id, string deletionInfo)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                var param = new { ID = id, DeletionInfo = deletionInfo };
                conn.ExecuteStored("spUserDelete", param);
            }
        }

        public void UpdateUser(UserData userData)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                throw new NotImplementedException();
            }
        }

        public void SetEmail(int id, string email)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                throw new NotImplementedException();
            }
        }

        public void SetUsername(int id, string username)
        {
            using (IDbConnection conn = _access.GetConnection())
            {
                throw new NotImplementedException();
            }
        }

        public void SetPasswordHash(int id, string hash)
        {

        }
    }
}
