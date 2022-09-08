using Microsoft.EntityFrameworkCore;
using MovieRating.Data;
using SharedLibrary;

namespace MovieRating.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _db;

        public ReviewService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Review> CreateReview(Review review)
        {
            var result = await _db.Reviews.AddAsync(review);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Review>> GetReviewByMovieId(int id)
        {
            var reviews = await _db.Reviews.Where(x => x.Movie == id).ToListAsync();
            return reviews;
        }
        public async Task<double> GetAverageReviewByMovieId(int id)
        {
            var reviews = await _db.Reviews.Where(x => x.Movie == id).ToListAsync();
            if (reviews.Count > 0)
            {
                double combinedScore = 0;
                int numberOfReviews = 0;
                double averageRating = 0;
                foreach (var review in reviews)
                {
                    combinedScore = combinedScore + review.Rating;
                    numberOfReviews++;
                }

                return combinedScore / numberOfReviews;

            }
            return 0;
        }
        public async Task<double> GetUsersScoreByUserEmailAndMovieId(int id, string userEmail)
        {
            var review = await _db.Reviews.FirstOrDefaultAsync(x => x.UserEmail == userEmail && x.Movie == id);
            if (review != null)
            {
                var returnRating = review.Rating;
                return returnRating;
            }
            return 0;
        }
    }
}
