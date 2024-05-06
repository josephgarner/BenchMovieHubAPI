using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewResponse>> GetReviewsForMovie(int movieId);

    Task CreateMovieReview(int movieId, ReviewDto incomingReview);
    
    Task<Task> UpdateMovieReview(int movieId, int reviewId, ReviewDto incomingReview);

    Task<decimal> GetAverageScore(int movieId);

    Task<Task> DeleteMovieReview(int movieId, int reviewId);
    
    Task<bool> SaveChanges();
}