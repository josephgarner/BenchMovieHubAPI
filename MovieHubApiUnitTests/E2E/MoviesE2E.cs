using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MovieHubAPI.Database;
using MovieHubAPI.domain;
using MovieHubApiUnitTests.Fixtures;

namespace MovieHubApiUnitTests.E2E;

public class MovieE2E(TestingWebAppFactory<Program> factory) : IClassFixture<TestingWebAppFactory<Program>>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task GET_Movie_List()
    {
        using (var scope = factory.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<MovieHubContext>();

            await db.Database.EnsureCreatedAsync();
            Seeding.InitDb(db);
        }
        
        var response = await _client.GetAsync($"movies");

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<List<MovieSummaryDto>>();
        Assert.NotNull(result);
        Assert.Equal(3, result.Count);
    }
    
    [Fact]
    public async Task GET_Movie_Details()
    {
        using (var scope = factory.Services.CreateScope())
        {
            
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<MovieHubContext>();

            await db.Database.EnsureCreatedAsync();
            Seeding.InitDb(db);
        }
        
        var response = await _client.GetAsync($"movies/2");

        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<MovieDto>();
        Assert.NotNull(result);
            
        Assert.Equal("Star Wars: Attack of the Clones (Episode II)", result.Title);
        Assert.Equal(2, result.MovieCinemas.Count());
        Assert.Contains(result.MovieCinemas, cinema => cinema.CinemaName == "Moviemania");
        Assert.Contains(result.MovieCinemas, cinema => cinema.CinemaName == "BigScreen Bliss");
        Assert.Contains(result.MovieCinemas, cinema => cinema.TicketPrice == (decimal)21.25);
    }
}