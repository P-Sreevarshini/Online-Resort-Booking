
// using Microsoft.EntityFrameworkCore;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using dotnetapp.Models;

// namespace dotnetapp.Repository
// {
//     public class UserRepo
//     {
//         private readonly ApplicationDbContext _context;

//         public UserRepo(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<User> GetUserByEmailAsync(string email)
//         {
//             return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
//         }

//         public async Task<User> AddUserAsync(User user)
//         {
//             _context.Users.Add(user);
//             await _context.SaveChangesAsync();
//             return user;
//         }

//         public async Task<List<User>> GetAllUsersAsync()
//         {
//             return await _context.Users.ToListAsync();
//         }
//     }
// }
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
    }

    public class UserRepo : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
