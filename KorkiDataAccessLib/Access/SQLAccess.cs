using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
//using Microsoft.Extensions.Configuration;

namespace KorkiDataAccessLib.Access
{
    public class SQLAccess : ISQLAccess
    {
        private readonly IConfiguration _config;
        private string korkiConnName = "KorkiDBConnection";
        public string ConnectionStr => _config.GetConnectionString(korkiConnName);

        public SQLAccess(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionStr);
        }
    }
}
