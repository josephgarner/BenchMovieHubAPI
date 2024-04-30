using Microsoft.Data.Sqlite;

namespace MovieHubApiUnitTests.Fixtures;

public class DatabaseFixture : IDisposable
{
    public SqliteConnection Db { get; private set; }
    
    public DatabaseFixture()
    {
        Db = new SqliteConnection("DataSource=:memory:");
        Db.Open();
    }
    
    public void SetupDatabase()
    {
        using SqliteCommand command = new();
        command.CommandText = File.ReadAllText("../../../moviehub_db_data_seed.sql");
        command.Connection = Db;
        command.ExecuteNonQuery();
    }

    public void Dispose()
    {
        Db.Close();
    }
}