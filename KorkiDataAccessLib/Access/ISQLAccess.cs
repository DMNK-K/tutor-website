using System.Data.SqlClient;

namespace KorkiDataAccessLib.Access
{
    public interface ISQLAccess
    {
        string ConnectionStr { get; }

        SqlConnection GetConnection();
    }
}