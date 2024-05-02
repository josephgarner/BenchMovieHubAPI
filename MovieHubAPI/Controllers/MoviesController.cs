using Microsoft.AspNetCore.Mvc;
using MovieHubAPI.Services;

namespace MovieHubAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private static ILogger<MovieController> _logger;
    private static IMovieService _movieService;

    public MoviesController(ILogger<MovieController> logger, IMovieService movieService)
    {
        _logger = logger;
        _movieService = movieService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        _logger.LogInformation("Getting list of movies");
        return Ok(await _movieService.GetMoviesAsync());
    }
}