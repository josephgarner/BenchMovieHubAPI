using System.Net;
using Microsoft.Extensions.DependencyInjection;
using MovieHubAPI.Clients.http;
using MovieHubAPI.Database;

namespace MovieHubApiUnitTests.E2E.Fixtures;

public class TestSetup : IClassFixture<TestingWebAppFactory<Program>>
{
    protected HttpClient Client { get;  }
    protected TestingWebAppFactory<Program> Factory { get; }
    private const string BaseUrl = "https://integration.test/api/v2/";

    protected TestSetup(TestingWebAppFactory<Program> factory)
    {
        Factory = factory;
        Client = Factory.CreateClient();
        using (var scope = Factory.Services.CreateScope())
        {
            var filmWorldResponse = new PrincesResponse
            {
                Movies =
                [
                    new PrincesMovie("fw0121765", (decimal)32.7),
                ]
            };
            factory.MockMessageHandler.SetupSendAsync(HttpMethod.Get, $"{BaseUrl}filmworld/movies")
                .ReturnsHttpResponseAsync(filmWorldResponse, HttpStatusCode.OK);
            var cinemaWorldResponse = new PrincesResponse
            {
                Movies =
                [
                    new PrincesMovie("cw0121765", (decimal)31.2),
                ]
            };

            factory.MockMessageHandler.SetupSendAsync(HttpMethod.Get, $"{BaseUrl}cinemaworld/movies")
                .ReturnsHttpResponseAsync(cinemaWorldResponse, HttpStatusCode.OK);
            
            var scopedServices = scope.ServiceProvider;
            var db = scopedServices.GetRequiredService<MovieHubContext>();
            Seeding.InitDb(db);
        }
    }
}