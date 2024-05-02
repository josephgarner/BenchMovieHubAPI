using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MovieHubAPI.Database;

namespace MovieHubApiUnitTests.Fixtures;

public class DatabaseFixture : IDisposable
{
    public SqliteConnection Db { get; private set; }
    
    public DatabaseFixture()
    {
        Db = new SqliteConnection("DataSource=:memory:");
        Db.Open();
    }
    
    public MovieHubContext SetupDatabase()
    {
        
        var dbOption = new DbContextOptionsBuilder<MovieHubContext>()
            .UseSqlite(Db)
            .Options;
        var context = new MovieHubContext(dbOption);
        context.Database.EnsureCreatedAsync();
        
        using SqliteCommand command = new();
        command.CommandText = File.ReadAllText("../../../moviehub_db_data_seed.sql");
        command.Connection = Db;
        command.ExecuteNonQuery();
        
        return context;
    }
    
    public void Reset()
    {
        Db.Close();
        Db = new SqliteConnection("DataSource=:memory:");
        Db.Open();
    }

    public void Dispose()
    {
        Db.Close();
    }
}

