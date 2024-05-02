namespace MovieHubAPI.domain;

public class ReviewDto(decimal Score, string Comment, DateTime ReviewDate)
{
    public int Id { get; private set; }
    public decimal Score { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }
}