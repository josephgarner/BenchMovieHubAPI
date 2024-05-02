using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database.Entities;

namespace MovieHubAPI.Database;

public class MovieHubContext : DbContext
{
    public MovieHubContext(){}
    
    public MovieHubContext(DbContextOptions<MovieHubContext> options): base(options) {}
    
    public DbSet<Movie> Movie { get; set; }
    
    public DbSet<MovieCinema> MovieCinema { get; set; }
    
    public DbSet<Cinema> Cinema { get; set; }
    
    public DbSet<MovieReview> MovieReview { get; set; }
    
}