using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;
using MovieHubAPI.Profiles;
using MovieHubAPI.Services;
using MovieHubApiUnitTests.Fixtures;

namespace MovieHubApiUnitTests.UnitTests;

[Collection("Database collection")]
public class MovieServiceTest
{
    private IMovieService _repo;

    public MovieServiceTest(DatabaseFixture dbFixture)
    {
        var dbOption = new DbContextOptionsBuilder<MovieHubContext>()
            .UseSqlite(dbFixture.Db)
            .Options;
        var context = new MovieHubContext(dbOption);
        context.Database.EnsureCreatedAsync();
        dbFixture.SetupDatabase();
        
        // Mapper
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MovieProfile>());
        IMapper mapper = new Mapper(config);
        
        // Service
        _repo = new MovieService(context, mapper);
    }
    
    [Fact]
    public async void Get_All_Movies()
    {
        //Arrange
        //Act
        var result = await _repo.GetMoviesAsync();

        //Assert
        var movieSummaries = result.ToList();
        
        Assert.Equal(9, movieSummaries.Count);
        
        Assert.Contains(movieSummaries, movie => movie.Id == 1);
        Assert.Contains(movieSummaries, movie => movie.Title == "Star Wars: The Phantom Menace (Episode I)");
        Assert.Contains(movieSummaries, movie => movie.Genre == "Action, Adventure, Fantasy, Live Action, Science Fiction");
        
        Assert.Contains(movieSummaries, movie => movie.Id == 7);
        Assert.Contains(movieSummaries, movie => movie.Title == "Star Wars: The Force Awakens (Episode VII)");
        Assert.Contains(movieSummaries, movie => movie.Genre == "Action - Adventure, Science Fiction");
        Assert.Contains(movieSummaries, movie => movie.Genre == "Action - Adventure, Science Fiction");
    }

    [Fact]
    public async void Get_Movie_Details()
    {
        var result = await _repo.GetMovieAsync(3);

        Assert.NotNull(result);
        Assert.Equal("Star Wars: Revenge of the Sith (Episode III)", result.Title);
        Assert.Equal(8399, result.Runtime);
        Assert.Equal(7, result.MovieCinemas.Count());
        
        Assert.Contains(result.MovieCinemas, cinema => cinema.CinemaName == "CineNova");
    }
}