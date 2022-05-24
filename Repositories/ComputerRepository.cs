using LabManager.Models;
using LabManager.Database;
using Microsoft.Data.Sqlite;


namespace LabManager.Repositories;

class ComputerRepository
{
    private DatabaseConfig databaseConfig;

    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public List<Computer> GetAll()
    {
        var connection = new SqliteConnection("Data Source=database.db");
         connection.Open();
         var command = connection.CreateCommand();
         command.CommandText = "SELECT * FROM Computers;";

         var reader = command.ExecuteReader();

         var computers = new List<Computer>();

         while(reader.Read())
         {
             var computer = new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
             computers.Add(computer);
             
             
         }

         
         connection.Close();

         return computers;
    }

//public Computer Save(Computer)
  
}