namespace MovieHubAPI.domain.Response;

public class MovieCinemaSummaryResponse
{
    public string CinemaName { get; set; }
    public DateTime Showtime { get; set; }
    public decimal TicketPrice { get; set; }

    public MovieCinemaSummaryResponse(string cinemaName, DateTime showtime, decimal ticketPrice)
    {
        CinemaName = cinemaName;
        Showtime = showtime;
        TicketPrice = ticketPrice;
    }
}