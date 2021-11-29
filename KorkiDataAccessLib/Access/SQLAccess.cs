using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;

namespace KorkiDataAccessLib.Access
{
    public static class SQLAccess
    {
        private static string korkiConnName = "KorkiDBConnection";

        public static string KorkiConnectionStr => GetConnString(korkiConnName);

        public static string GetConnString(string connName)
        {
            return ConfigurationManager.ConnectionStrings[connName].ConnectionString;
        }
    }
}
