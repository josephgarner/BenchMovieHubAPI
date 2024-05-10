using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Clients;
using MovieHubAPI.Database;
using MovieHubAPI.domain;
using MovieHubAPI.Domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Services;

public class MovieService(MovieHubContext context, IMapper mapper, IReviewService reviewService, IPrincesTheatreClient client) : IMovieService
{
    private readonly IReviewService _reviewService =
        reviewService ?? throw new ArgumentNullException(nameof(reviewService));
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    private readonly IPrincesTheatreClient _client = client ?? throw new ArgumentNullException(nameof(client));

    public async Task<IEnumerable<MovieSummaryResponse>> GetMoviesAsync()
    {
        var movies = _mapper.Map<IEnumerable<MovieDto>>(await _context.Movie.ToListAsync());
        var filmWoldMovies = await _client.GetFilmWorldMovies();
        var cinemaWorldMovies = await _client.GetCinemaWorldMovies();
        
        foreach (var movie in movies)
        {
            movie.AverageScore = await _reviewService.GetAverageScore(movie.Id);
            var filmWorld = filmWoldMovies.Find(fw => fw.Id == $"fw{movie.PrincessTheatreMovieId}");
            var cinemaWorld = cinemaWorldMovies.Find(cw => cw.Id == $"cw{movie.PrincessTheatreMovieId}");
            movie.TicketPrices = new TicketPrice(filmWorld?.Price ?? 0, cinemaWorld?.Price ?? 0);     
        }
        var movieSumResp = _mapper.Map<IEnumerable<MovieSummaryResponse>>(movies).ToList();
        
        return movieSumResp;
    }

    public async Task<MovieResponse?> GetMovieAsync(int movieId)
    {
        var movie = _mapper.Map<MovieDto>(await _context.Movie.Where(m => m.Id == movieId).FirstOrDefaultAsync());
        var movieCinemas = await _context.MovieCinema.Where(mc => mc.MovieId == movieId).ToListAsync();
        var cinemas = await _context.Cinema.ToListAsync();

        var fwPrice = await _client.GetFilmWorldMovie(movie.PrincessTheatreMovieId);
        var cwPrice = await  _client.GetCinemaWorldMovie(movie.PrincessTheatreMovieId);
        
        movie.AverageScore = await _reviewService.GetAverageScore(movie.Id);
        movie.TicketPrices = new TicketPrice(fwPrice.Price, cwPrice.Price);
        
        
        var movieResponse = _mapper.Map<MovieResponse>(movie);
        
        List<MovieCinemaSummaryResponse> showTimes = (from mc in movieCinemas let cinema = cinemas.Find(c => c.Id == mc.CinemaId) select new MovieCinemaSummaryResponse(cinema!.Name, mc.Showtime, mc.TicketPrice)).ToList();
        movieResponse.MovieCinemas = showTimes;
        
        return movieResponse;
    }
}