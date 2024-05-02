using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;

namespace MovieHubAPI.Services;

public class ReviewService(MovieHubContext context, IMapper mapper) : IReviewService
{
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<ReviewDto>> GetReviewsForMovie(int movieId)
    {
        var reviewList = await _context.MovieReview.Where(mr => mr.MovieId == movieId).ToListAsync();
        return _mapper.Map<IEnumerable<ReviewDto>>(reviewList);
    }

    public Task CreateMovieReview(int movieId, ReviewDto incomingReview)
    {
        var review = _mapper.Map<MovieReview>(incomingReview);
        review.MovieId = movieId;
        _context.MovieReview.Add(review);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChanges()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}