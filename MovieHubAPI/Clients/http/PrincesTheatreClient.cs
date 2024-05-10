namespace MovieHubAPI.Clients.http;

public class PrincesTheatreClient(HttpClient client) : IPrincesTheatreClient
{
    private readonly HttpClient _client =
        client ?? throw new ArgumentNullException(nameof(client));
    public async Task<List<PrincesMovie>> GetFilmWorldMovies()
    {
        var response = await _client.GetFromJsonAsync<PrincesResponse>("filmworld/movies");
        return response.Movies;
    }

    public async Task<PrincesMovie> GetFilmWorldMovie(string princesId)
    {
        var response = await _client.GetFromJsonAsync<PrincesResponse>("filmworld/movies");
        return response?.Movies.FirstOrDefault(m => m.Id == $"fw{princesId}") ?? new PrincesMovie("", 0);
    }
    
    public async Task<List<PrincesMovie>> GetCinemaWorldMovies()
    {
        var response = await _client.GetFromJsonAsync<PrincesResponse>("cinemaworld/movies");
        return response.Movies;
    }
    
    public async Task<PrincesMovie> GetCinemaWorldMovie(string princesId)
    {
        var response = await _client.GetFromJsonAsync<PrincesResponse>("cinemaworld/movies");
        return response?.Movies.FirstOrDefault(m => m.Id == $"cw{princesId}") ?? new PrincesMovie("", 0);
    }
}

public class PrincesResponse
{
    public  List<PrincesMovie> Movies { get; set; }
}

public class PrincesMovie
{
    public PrincesMovie(string id, decimal price)
    {
        Id = id;
        Price = price;
    }
    public string Id { get; set; }
    public decimal Price { get; set; }
}