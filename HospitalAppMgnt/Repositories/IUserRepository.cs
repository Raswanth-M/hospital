using HospitalAppMgnt.Models;

namespace HospitalAppMgnt.Repositories
{
    public interface IUserRepository
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string username, string password);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
