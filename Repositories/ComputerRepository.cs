using LabManager.Models;
using LabManager.Database;
using Microsoft.Data.Sqlite;


namespace LabManager.Repositories;

class ComputerRepository
{
    private readonly DatabaseConfig _databaseConfig;
    
    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public IEnumerable<Computer> GetAll()
    //Antes do IE estava List

    {

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
 
        var computers = connection.Query<Computer>("SELECT * FROM Computers");

        return computers;
    }

public Computer Save(Computer computer)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Computers VALUES (@Id, @Ram, @Processor)", computer);

        connection.Close();

        return computer;
} 

public Computer GetById(int id)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = "SELECT * FROM Computers WHERE id = $id;";
    command.Parameters.AddWithValue("$id", id);

    var reader = command.ExecuteReader();
    reader.Read();

    var computer = ReaderToComputer(reader);

    connection.Close();
    return computer;
}

public void Delete(int id)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    connection.Execute("DELETE FROM Computers WHERE id = @Id;", new {Id = @id});

    connection.Close();
}

public Computer Update(Computer computer)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    connection.Execute("UPDATE Computers SET ram = @Ram, processor = @Processor Where id = @Id;", computer);

    connection.Close();

    return computer;
}

public bool ExitsById(int id)
{
    var connection = new SqliteConnection(_databaseConfig.ConnectionString);
    connection.Open();

    var result = connection.ExecuteScalar<Boolean>("SELECT COUNT(id) FROM Computers WHERE id=@id;", new {Id = @id});

    return result;
}

private Computer ReaderToComputer(SqliteDataReader reader)
{
    var computer = new Computer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

    return computer;
}

  
}