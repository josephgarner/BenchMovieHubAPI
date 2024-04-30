using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieHubAPI.domain;
using MovieHubAPI.Services;

namespace MovieHubAPI.Endpoints;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", GetAllMovies);
        app.MapGet("/movies/{id}", GetMovie);
    }

    [HttpGet]
    private static async Task<IEnumerable<MovieSummaryDto>> GetAllMovies(IMovieInfoRepository repo)
    {
        return await repo.GetMoviesAsync();
        
    }

    [HttpGet]
    private static async Task<MovieDto?> GetMovie(IMovieInfoRepository repo, int id)
    {
        return await repo.GetMovieAsync(id);
    }
}