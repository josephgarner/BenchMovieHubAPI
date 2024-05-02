using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubAPI.Database.Entities;

public class MovieCinema
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    [ForeignKey("Cinema")]
    public int CinemaId { get; set; }
    public DateTime Showtime { get; set; }
    public decimal TicketPrice { get; set; }

    public MovieCinema(int movieId, int cinemaId, DateTime showtime, decimal ticketPrice)
    {
        MovieId = movieId;
        CinemaId = cinemaId;
        Showtime = showtime;
        TicketPrice = ticketPrice;
    }
}