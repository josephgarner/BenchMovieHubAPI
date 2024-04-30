using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;

namespace MovieHubAPI.Services;

public interface IMovieInfoService
{
    Task<IEnumerable<MovieSummaryDto>> GetMoviesAsync();

    Task<MovieDto?> GetMovieAsync(int movieId);
}