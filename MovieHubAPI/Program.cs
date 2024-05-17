using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Http.Resilience;
using MovieHubAPI.Clients;
using MovieHubAPI.Clients.http;
using MovieHubAPI.Database;
using MovieHubAPI.Services;
using Polly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IReviewService, ReviewService>();

builder.Services.AddDbContext<MovieHubContext>(options => options.UseSqlite("Name=MovieHubDB"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiKey = builder.Configuration["PrincessTheatreAPIKey"];
var clientBuilder = builder.Services.AddHttpClient<IPrincesTheatreClient, PrincesTheatreClient>("princesTheatre",
    client =>
    {
        client.BaseAddress = new Uri("https://challenge.lexicondigital.com.au/api/v2/");
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        
    });
clientBuilder.AddResilienceHandler("PrincesPipeline", rb =>
{
    rb.AddRetry(new HttpRetryStrategyOptions
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 4,
        UseJitter = true
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

public partial class Program { }