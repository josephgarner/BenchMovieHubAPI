using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.Database.Entities;
using MovieHubAPI.domain;
using MovieHubAPI.domain.Response;

namespace MovieHubAPI.Services;

public class ReviewService(MovieHubContext context, IMapper mapper) : IReviewService
{
    private readonly MovieHubContext _context = context ?? throw new ArgumentNullException(nameof(context));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    public async Task<IEnumerable<ReviewResponse>> GetReviewsForMovie(int movieId)
    {
        var reviewList =
            _mapper.Map<IEnumerable<ReviewDto>>(await _context.MovieReview.Where(mr => mr.MovieId == movieId)
                .ToListAsync());
        return _mapper.Map<IEnumerable<ReviewResponse>>(reviewList);
    }

    public Task CreateMovieReview(int movieId, ReviewDto incomingReview)
    {
        var review = _mapper.Map<MovieReview>(incomingReview);
        review.MovieId = movieId;
        _context.MovieReview.Add(review);
        return Task.CompletedTask;
    }

    public async Task<Task> UpdateMovieReview(int movieId, int reviewId, ReviewDto incomingReview)
    {
        var existing = mapper.Map<ReviewDto>(await _context.MovieReview.FirstOrDefaultAsync(r => r.Id == reviewId && r.MovieId == movieId));
        
        var updatedReview = mapper.Map<MovieReview>(existing.MergeWith(incomingReview));
        updatedReview.MovieId = movieId;
        
        _context.ChangeTracker.Clear();
        _context.MovieReview.Update(updatedReview);
        return Task.CompletedTask;
    }

    public async Task<decimal> GetAverageScore(int movieId)
    {
        var score = await _context.MovieReview.Where(r => r.MovieId == movieId).SumAsync(r => (double)r.Score);
        var reviewCount = _context.MovieReview.Count(r => r.MovieId == movieId);
        return score > 0 ? (decimal)(score / reviewCount) : 0;
    }

    public async Task<Task> DeleteMovieReview(int movieId, int reviewId)
    {
        var toBeDeleted = await _context.MovieReview.FirstOrDefaultAsync(r => r.Id == reviewId && r.MovieId == movieId);
        if (toBeDeleted != null) _context.MovieReview.Remove(toBeDeleted);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChanges()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}