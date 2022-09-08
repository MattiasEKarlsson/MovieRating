using SharedLibrary;

namespace MovieRating.Services
{
    public interface IReviewService
    {
        Task<Review> CreateReview(Review request);
        Task<List<Review>> GetReviewByMovieId(int id);
        Task<double> GetAverageReviewByMovieId(int id);
        Task<double> GetUsersScoreByUserEmailAndMovieId(int id, string userEmail);
    }
}