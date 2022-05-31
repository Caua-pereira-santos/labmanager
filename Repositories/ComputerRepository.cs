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

public void Save(Computer computer)
{
    var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES ($id, $ram, $processor);"
        ;
        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();

        return computer;
} 

ComputerRepository GetId(int id)
{
    var connection = new sqliteConnection(databaseConfig.ConnectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Computers WHERE id = $id;";
    command.Parameters.AddWithValue("$id", id);

    var reader = command.ExecuteReader();
    reader.Read();
    var computer = new ComputerRepository(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

    connection.Close();
    return computer;
}

public void Delete(int id)
{
    var connection = new sqliteConnection(databaseConfig.ConnectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "DELETE FROM Computers WHERE id = $id;";
    command.Parameters.AddWithValue("$id", id);

    command.ExecuteNonQuery();
    connection.Close();
}

public Comput Update(Computer computer)
{
    var connection = new sqliteConnection(databaseConfig.connectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "UPDATE Computers SET ram =  $ram, processor = $processor WHERE id = $id;";

    command.Parameters.AddWithValue("$id", computer.Id);
    command.Parameters.AddWithValue("$ram", computer.Ram);
    command.Parameters.AddWithValue("$id", computer.Processor);

    command.ExecuteNonQuery();
    connection.Close();

    return computer;
}

  
}