namespace MovieHubAPI.domain;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public int Runtime { get; set; }
    public string Synopsis { get; set; }
    public string Director { get; set; }
    public string Rating { get; set; }
    public string PrincessTheatreMovieId { get; set; }

    public MovieDto(int id, string title, DateTime releaseDate, string genre, int runtime, string synopsis,
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
    }
}