namespace MovieHubAPI.Domain;

public class TicketPrice
{
    public TicketPrice(decimal filmWorld, decimal cinemaWorld)
    {
        FilmWorld = filmWorld;
        CinemaWorld = cinemaWorld;
    }

    public decimal FilmWorld { get; set; }
    public decimal CinemaWorld { get; set; }
}