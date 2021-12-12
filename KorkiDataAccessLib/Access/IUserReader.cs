using KorkiDataAccessLib.Models;
using System.Threading.Tasks;

namespace KorkiDataAccessLib.Access
{
    public interface IUserReader
    {
        Task<UserData> GetUser(int id);
        Task<UserData> GetUserByEmail(string email);
        Task<UserData> GetUserByUsername(string username);
    }
}