
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Repository
{
    public interface IReviewRepo
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId);
    }

    public class ReviewRepo : IReviewRepo // changed class name to ReviewRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewRepo(ApplicationDbContext dbContext) // corrected the constructor name
        {
            _dbContext = dbContext;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
                             return await _dbContext.Reviews
                         .Include(b => b.User) // Include user data
                         .ToListAsync();       
                          }       

        public async Task<Review> AddReviewAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId)
        {
            // return await _dbContext.Reviews.Where(r => r.UserId == userId).ToListAsync();
             return await _dbContext.Reviews
                                .Where(b => b.UserId == userId)
                                .Include(b => b.User)
                                .ToListAsync();
        }
    }
}
