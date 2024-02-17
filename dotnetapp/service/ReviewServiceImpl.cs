using dotnetapp.Models;
using dotnetapp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Service
{
    public class ReviewServiceImpl : ReviewService
    {
        private readonly ReviewRepo _reviewRepo;

        public ReviewServiceImpl(ReviewRepo reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepo.GetAllReviewsAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            return await _reviewRepo.AddReviewAsync(review);
        }
    }
}
