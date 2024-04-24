using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubAPI.Database.Entities;

public class Movie
{
    [Key]
    [DatabaseGenerated((DatabaseGeneratedOption.Identity))]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(128)]
    public string Title { get; set; }
    
    [Required]
    public DateTime ReleaseDate { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string Genre { get; set; }
    
    [Required]
    public int Runtime { get; set; }
    
    [Required]
    public string Synopsis { get; set; }
    
    [Required]
    [MaxLength(64)]
    public string Director { get; set; }
    
    [Required]
    [MaxLength(8)]
    public string Rating { get; set; }
    
    [Required]
    [MaxLength(16)]
    public string PrincessTheatreMovieId { get; set; }

    public Movie(string title, DateTime releaseDate, string genre, int runtime, string synopsis,
        string director, string rating,
        string princessTheatreMovieId)
    {
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