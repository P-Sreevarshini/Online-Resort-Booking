using dotnetapp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Service
{
    public interface ReviewService
    {
        Task<List<Review>> GetAllReviewsAsync();
        Task<Review> AddReviewAsync(Review review);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId);

    }
}
