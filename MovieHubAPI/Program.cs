using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IReviewService, ReviewService>();

builder.Services.AddDbContext<MovieHubContext>(options => options.UseSqlite("Name=MovieHubDB"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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