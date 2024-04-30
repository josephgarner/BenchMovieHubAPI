namespace MovieHubAPI.domain;

public class MovieCinemaDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public DateTime Showtime { get; set; }
    public decimal TicketPrice { get; set; }
    
    public MovieCinemaDto(){}
}