namespace MovieHubAPI.domain.Response;

public class ReviewResponse
{
    public int Id { get; private set; }
    public decimal Score { get; set; }
    public string Comment { get; set; }
    public DateTime ReviewDate { get; set; }

    public ReviewResponse(decimal score, string comment, DateTime reviewDate)
    {
        Score = score;
        Comment = comment;
        ReviewDate = reviewDate;
    }
}