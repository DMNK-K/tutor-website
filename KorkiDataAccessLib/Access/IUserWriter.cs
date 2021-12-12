using KorkiDataAccessLib.Models;
using System.Threading.Tasks;

namespace KorkiDataAccessLib.Access
{
    public interface IUserWriter
    {
        Task<int> CreateUser(UserData userData);
        Task<int> CreateUserWithTutor(UserData userData, string nameFirst, string nameLast, int cityID);
        Task<int> DeleteUser(int id, string deletionInfo);
        //Task<int> SetEmail(int id, string email);
        //Task<int> SetPasswordHash(int id, string hash);
        //Task<int> SetUsername(int id, string username);
        Task<int> UpdateUser(UserData userData);
    }
}