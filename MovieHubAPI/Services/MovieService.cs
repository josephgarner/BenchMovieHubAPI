using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.domain;

namespace MovieHubAPI.Services;

public class MovieService(MovieHubContext context, IMapper mapper) : IMovieService
{
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<MovieSummaryDto>> GetMoviesAsync()
    {
        var movies = await _context.Movie.ToListAsync();
        return _mapper.Map<IEnumerable<MovieSummaryDto>>(movies);
    }

    public async Task<MovieDto?> GetMovieAsync(int movieId)
    {
        var movie = _mapper.Map<MovieDto>(await _context.Movie.Where(m => m.Id == movieId).FirstOrDefaultAsync());
        var movieCinemas = await _context.MovieCinema.Where(mc => mc.MovieId == movieId).ToListAsync();
        var cinemas = await _context.Cinema.ToListAsync();
        
        List<MovieCinemaSummaryDto> showTimes = (from mc in movieCinemas let cinema = cinemas.Find(c => c.Id == mc.CinemaId) select new MovieCinemaSummaryDto(cinema!.Name, mc.Showtime, mc.TicketPrice)).ToList();
        movie.MovieCinemas = showTimes;
        
        return movie;
    }
}