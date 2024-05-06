using Microsoft.AspNetCore.Mvc;
using MovieHubAPI.domain;
using MovieHubAPI.Services;

namespace MovieHubAPI.Controllers;

[Route("[controller]/{id:int}")]
[ApiController]
public class MovieController : ControllerBase
{
    private static ILogger<MovieController> _logger;
    private static IMovieService _movieService;
    private static IReviewService _reviewService;

    public MovieController(ILogger<MovieController> logger, IMovieService movieService, IReviewService reviewService)
    {
        _logger = logger;
        _movieService = movieService;
        _reviewService = reviewService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetMovie(int id)
    {
        _logger.LogInformation($"Getting movie with movieId of {id}");
        var movie = await _movieService.GetMovieAsync(id);
        return movie == null ? NotFound() : Ok(movie);
        // TODO Fix average score problem
    }

    [HttpGet("reviews")]
    public async Task<IActionResult> GetReviews(int id)
    {
        _logger.LogInformation($"Getting Movie reviews with the movie id of {id}");
        return Ok(await _reviewService.GetReviewsForMovie(id));
    }

    [HttpPost("review/submit")]
    public async Task<IActionResult> PostReview(int id, [FromBody] ReviewDto reviewDto)
    {
        _logger.LogInformation($"Saving movie review for movie with id {id}");
        
        await _reviewService.CreateMovieReview(id, reviewDto);
        await _reviewService.SaveChanges();

        return NoContent();
    }

    [HttpPut("review/{reviewId:int}")]
    public async Task<IActionResult> PutUpdate(int id, int reviewId, [FromBody] ReviewDto reviewDto)
    {
        _logger.LogInformation($"Updating movie review for movieId {id} and reviewId {reviewId}");

        await _reviewService.UpdateMovieReview(id, reviewId, reviewDto);
        await _reviewService.SaveChanges();

        return NoContent();
    }

    [HttpDelete("review/{reviewId:int}")]
    public async Task<IActionResult> Delete(int id, int reviewId)
    {
        _logger.LogInformation($"Deleting movie review for movieId {id} and reviewId {reviewId}");
        await _reviewService.DeleteMovieReview(id, reviewId);
        await _reviewService.SaveChanges();
        return NoContent();
    }
    
}