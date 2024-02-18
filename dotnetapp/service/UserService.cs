// UserService.cs

using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Service
{
    public interface UserService
    {
        Task<User> RegisterUserAsync(User user);
        Task<string> GenerateJwtTokenAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<List<User>> GetAllUsersAsync();
                Task<User> GetUserByIdAsync(long userId); // Add GetUserByIdAsync method


    } 
}
