using MovieHubAPI.domain;

namespace MovieHubAPI.Services;

public interface IReviewService
{
    Task<IEnumerable<ReviewDto>> GetReviewsForMovie(int movieId);

    Task CreateMovieReview(int movieId, ReviewDto incomingReview);

    Task<bool> SaveChanges();
}