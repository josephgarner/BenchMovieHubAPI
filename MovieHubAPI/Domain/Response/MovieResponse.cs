namespace MovieHubAPI.domain.Response;

public class MovieResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public DateTime ReleaseDate { get; init; }
    public string Genre { get; init; }
    public int Runtime { get; init; }
    public string Synopsis { get; init; }
    public string Director { get; init; }
    public string Rating { get; init; }
    
    public decimal AverageScore { get; set; }
    public string PrincessTheatreMovieId { get; init; }
    
    public IEnumerable<MovieCinemaSummaryResponse> MovieCinemas { get; set; }

    public MovieResponse(int id, string title, DateTime releaseDate, string genre, int runtime, string synopsis,
        string director, string rating,
        string princessTheatreMovieId)
    {
        Id = id;
        Title = title;
        ReleaseDate = releaseDate;
        Genre = genre;
        Runtime = runtime;
        Synopsis = synopsis;
        Director = director;
        Rating = rating;
        PrincessTheatreMovieId = princessTheatreMovieId;
        MovieCinemas = [];
    }
}