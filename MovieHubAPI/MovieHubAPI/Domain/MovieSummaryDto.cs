namespace MovieHubAPI.domain;

public class MovieSummaryDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }

    public MovieSummaryDto(int id, string title, string genre)
    {
        this.Id = id;
        this.Title = title;
        this.Genre = genre;
    }
}