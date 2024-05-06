namespace MovieHubAPI.domain.Response;

public class MovieSummaryResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    
    public decimal AverageScore { get; set; }

    public MovieSummaryResponse(int id, string title, string genre)
    {
        this.Id = id;
        this.Title = title;
        this.Genre = genre;
    }
}