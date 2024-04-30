namespace MovieHubAPI.domain;

public class MovieCinemaSummaryDto
{
    public string CinemaName { get; set; }
    public DateTime Showtime { get; set; }
    public decimal TicketPrice { get; set; }

    public MovieCinemaSummaryDto(string cinemaName, DateTime showtime, decimal ticketPrice)
    {
        CinemaName = cinemaName;
        Showtime = showtime;
        TicketPrice = ticketPrice;
    }
}