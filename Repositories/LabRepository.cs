using LabManager.Models;
using LabManager.Database;
using Microsoft.Data.Sqlite;
using Dapper;


namespace LabManager.Repositories;

class LabRepository
{
    private DatabaseConfig databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public List<Lab> GetAll()

    {
        using var connection = new SqliteConnection("Data Source=database.db");
         connection.Open();
         return  connection.Query<Lab>("SELECT * FROM Labs;").ToList();
    }

public Lab Save(Lab lab)
{
    using var connection = new SqliteConnection(databaseConfig.ConnectionString);
         connection.Open();
         connection.Execute("INSERT INTO Labs VALUES(@id, @number, @name, @block);", lab);
         return lab;
      
}
  
}