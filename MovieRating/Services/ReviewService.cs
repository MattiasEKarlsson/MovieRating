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
    }
}
