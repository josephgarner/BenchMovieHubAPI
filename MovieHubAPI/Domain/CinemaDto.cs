namespace MovieHubAPI.domain;

public class CinemaDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public CinemaDto(string name, string location)
    {
        Name = name;
        Location = location;
    }
}