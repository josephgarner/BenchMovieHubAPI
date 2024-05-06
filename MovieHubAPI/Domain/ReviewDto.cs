using Newtonsoft.Json;

namespace MovieHubAPI.domain;


public class ReviewDto
{
    public int Id { get; private set; }
    public decimal? Score { get; set; }
    public string? Comment { get; set; }
    public DateTime? ReviewDate { get; set; }

    [JsonConstructor]
    public ReviewDto()
    {
    }

    public ReviewDto(decimal score, string comment, DateTime reviewDate)
    {
        Score = score;
        Comment = comment;
        ReviewDate = reviewDate;
    }

    /**
     * Overwrites current instance with properties from the incoming object 
     */
    public ReviewDto MergeWith(ReviewDto incoming)
    {
        foreach (var property in typeof(ReviewDto).GetProperties())
        {
            if (property.Name == "Id") continue;
            var value  = property.GetValue(incoming) ?? property.GetValue(this);
            property.SetValue(this, value);

        }

        return this;
    }
}