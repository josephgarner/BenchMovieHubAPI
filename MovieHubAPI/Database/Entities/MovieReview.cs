using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieHubAPI.Database.Entities;

public class MovieReview
{
    public MovieReview(int movieId, decimal score, string comment, DateTime reviewDate)
    {
        MovieId = movieId;
        Score = score;
        Comment = comment;
        ReviewDate = reviewDate;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [ForeignKey("Movie")]
    public int MovieId { get; set; }
    [Required]
    public decimal Score { get; set; }
    [Required]
    public string Comment { get; set; }
    [Required]
    public DateTime ReviewDate { get; set; }
}