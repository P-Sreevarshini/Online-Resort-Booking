using dotnetapp.Models;
using dotnetapp.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnetapp.Service
{
    public class ReviewServiceImpl : ReviewService
    {
        private readonly ReviewRepo _reviewRepo;
        private readonly UserService _userService; // Inject UserService


        // public ReviewServiceImpl(ReviewRepo reviewRepo)
        // {
        //     _reviewRepo = reviewRepo;

        // }
         public ReviewServiceImpl(ReviewRepo reviewRepo, UserService userService) // Add UserService parameter
        {
            _reviewRepo = reviewRepo;
            _userService = userService; // Assign injected UserService
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            return await _reviewRepo.GetAllReviewsAsync();
        }

        public async Task<Review> AddReviewAsync(Review review)
        {
            return await _reviewRepo.AddReviewAsync(review);
        }
        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(long userId)
        {
            return await _reviewRepo.GetReviewsByUserIdAsync(userId);
        }
    }
}
