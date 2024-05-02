using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;

namespace MovieHubAPI.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieSummaryDto>> GetMoviesAsync();

    Task<MovieDto?> GetMovieAsync(int movieId);
}