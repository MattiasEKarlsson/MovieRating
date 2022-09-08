using SharedLibrary;

namespace MovieRating.Services
{
    public interface IMovieService
    {
        Task<Movie> CreateMovie(Movie movie);
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovieById(int id);
        Task CreateInitialMovies();
        Task<bool> DeleteMovieById(int movieId);
    }
}