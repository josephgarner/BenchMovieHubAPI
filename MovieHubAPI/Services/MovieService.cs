using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Services;

public class MovieService(MovieHubContext context, IMapper mapper, IReviewService reviewService) : IMovieService
{
    private readonly IReviewService _reviewService =
        reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<MovieSummaryResponse>> GetMoviesAsync()
    {
        var movies = _mapper.Map<IEnumerable<MovieDto>>(await _context.Movie.ToListAsync());
        var movieSumResp = _mapper.Map<IEnumerable<MovieSummaryResponse>>(movies).ToList();
        
        foreach (var movie in movieSumResp)
        {
            movie.AverageScore = await _reviewService.GetAverageScore(movie.Id);
        }
        
        return movieSumResp;
    }

    public async Task<MovieResponse?> GetMovieAsync(int movieId)
    {
        var movie = _mapper.Map<MovieDto>(await _context.Movie.Where(m => m.Id == movieId).FirstOrDefaultAsync());
        var movieCinemas = await _context.MovieCinema.Where(mc => mc.MovieId == movieId).ToListAsync();
        var cinemas = await _context.Cinema.ToListAsync();

        var movieResponse = _mapper.Map<MovieResponse>(movie);
        
        List<MovieCinemaSummaryResponse> showTimes = (from mc in movieCinemas let cinema = cinemas.Find(c => c.Id == mc.CinemaId) select new MovieCinemaSummaryResponse(cinema!.Name, mc.Showtime, mc.TicketPrice)).ToList();
        movieResponse.MovieCinemas = showTimes;
        
        return movieResponse;
    }
}