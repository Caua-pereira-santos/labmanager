using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    private DatabaseConfig databaseConfig;

    public DatabaseSetup(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
        CreateTableComputer();
        CreateLabTable();
    }
    private void CreateTableComputer()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

var command = connection.CreateCommand(); //cria uma tabela Computers
command.CommandText = @"

CREATE TABLE IF NOT EXISTS Computers(
    id int not null primary key,
    ram varchar(100) not null,
    processor varchar(100) not null
);



";
command.ExecuteNonQuery();
connection.Close();
    }

    private void CreateLabTable()
    {
        var connection = new SqliteConnection(databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand(); //Cria uma tabela Lab
        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS Lab(
    id int not null primary key,
    number int  not null,
    name varchar(100) not null,
    block varchar(100) not null);
    
    
    ";
    command.ExecuteNonQuery();
    connection.Close();
    }

 }







