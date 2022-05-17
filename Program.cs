// See https://aka.ms/new-console-template for more information
using LabManager.Database;
using Microsoft.Data.Sqlite;

var databaseConfig = new DatabaseConfig();
 new DatabaseSetup(databaseConfig);

 var ComputerRepository = new ComputerRepository();
 new DatabaseSetup(databaseConfig);

 var computerRepository = new ComputerRepository(databaseConfig);


Console.WriteLine(args);

foreach (var arg in args)
{
    Console.WriteLine(arg);
}

var modelName = args[0];
var modelAction = args[1];

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach (var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
         while(reader.Read())
         {
             Console.WriteLine("Computer List");
             Console.WriteLine("{0}, {1}, {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
             
         }

         reader.Close();
         connection.Close();
    }
        if(modelAction == "New")
    {
      var connection = new SqliteConnection("Data Source=database.db");

       connection.Open();

         Console.WriteLine("New computer");
        int id = Convert.ToInt32(args[2]);
        string ram = args[3];
        string processor = args[4];

        var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Computers VALUES($id, $ram, $processor)";
        command.Parameters.AddWithValue("$id", id);
        command.Parameters.AddWithValue("$ram", ram);
        command.Parameters.AddWithValue("$processor", processor);
        command.ExecuteNonQuery();

       connection.Close();

      
      
    }
    
}

if(modelName == "Lab")
{
   if(modelName == "List") 
   {
       connection = new SqliteConnection("Data Source=database.db");
       connection.Open();
       command = connection.CreateCommand();
       command.CommandText = "SELECT * FROM Lab;";

       var reader = command.ExecuteReader();

       while(reader.Read())
       {
           Console.WriteLine("Lab List");
           Console.WriteLine("{0}, {1}, {2}, {3}", reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3));
       }
        reader.Close();
        connection.Close();
   }
   if(modelAction == "New")
   {
       connection = new SqliteConnection("Data Source=database.db");

       connection.Open();

       Console.WriteLine("New Lab");
       int id = Convert.ToInt32(args[2]);
       int number = Convert.ToInt32(args[3]);
       string name = args[4];
       string block = args[5];

       command = connection.CreateCommand();
       command.CommandText = "INSERT INTO Computers VALUES($id, $number, $name, $block)";
       command.Parameters.AddWithValue("$id", id);
       command.Parameters.AddWithValue("$number", number);
       command.Parameters.AddWithValue("$name", name);
       command.Parameters.AddWithValue("$block", block);
       command.ExecuteNonQuery();

       connection.Close();
   }

  
}
