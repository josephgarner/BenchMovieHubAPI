using System.Net.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
            
            var response = await _client.GetAsync($"movies");

            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<List<MovieSummaryDto>>();
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }
    }
}