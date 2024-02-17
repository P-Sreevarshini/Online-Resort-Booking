// using dotnetapp.Models;
// using System.Collections.Generic;
// using System.Threading.Tasks;

// namespace dotnetapp.Repository
// {
//     public interface IReviewRepo
//     {
//         Task<List<Review>> GetAllReviewsAsync();
//         Task<Review> AddReviewAsync(Review review);
//     }

//     public class ReviewRepo : IReviewRepo
//     {
//         private List<Review> _reviews;

//         public ReviewRepo() // corrected the constructor name here
//         {
//             _reviews = new List<Review>();
//         }

//         public async Task<List<Review>> GetAllReviewsAsync()
//         {
//             return _reviews;
//         }

//         public async Task<Review> AddReviewAsync(Review review)
//         {
//             _reviews.Add(review);
//             return review;
//         }
//     }
// }
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
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            _dbContext.Reviews.Add(review);
            await _dbContext.SaveChangesAsync();
            return review;
        }
    }
}
