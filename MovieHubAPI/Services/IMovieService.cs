using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieSummaryResponse>> GetMoviesAsync();

    Task<MovieResponse?> GetMovieAsync(int movieId);
}