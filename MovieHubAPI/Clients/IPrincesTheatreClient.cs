using MovieHubAPI.Clients.http;

namespace MovieHubAPI.Clients;

public interface IPrincesTheatreClient
{
    Task<List<PrincesMovie>> GetFilmWorldMovies();
    
    Task<PrincesMovie> GetFilmWorldMovie(string princesId);

    Task<List<PrincesMovie>> GetCinemaWorldMovies();
    
    Task<PrincesMovie> GetCinemaWorldMovie(string princesId);
}