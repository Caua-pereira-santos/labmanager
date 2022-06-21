using LabManager.Repositories;
using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

var modelName = args[0];
var modelAction = args[1];

var databaseConfig = new DatabaseConfig();
var computerRepository = new ComputerRepository(databaseConfig);
var databaseSetup = new DatabaseSetup(databaseConfig);

if(modelName == "Computer")
{
    if(modelAction == "List")
    {
        Console.WriteLine("Computer List");
        foreach(var computer in computerRepository.GetAll())
        {
            Console.WriteLine("{0}, {1}, {2}", computer.Id, computer.Ram, computer.Processor);
        }
    }
    if(modelAction == "New")
    {
        var id = Convert.ToInt32(args[2]);
        var ram = args[3];
        var processor = args[4];

       var computer = new Computer(id, ram, processor);
       computerRepository.Save(computer);
    }
}

if(modelAction == "Show")
{
    var id = Convert.ToInt32(args[2]);

    if(computerRepository.ExitsById(id))
    {
        var computer = computerRepository.GetById(id);
        Console.WriteLine($"{computer.Id}, {computer.Ram}, {computer.Processor}");

    }
    else
    {
        Console.WriteLine($"O computador com Id {id} não existe.");
    }
}


    if(modelAction == "Update")
    {
        var id = Convert.ToInt32(args[2]);
        if(computerRepository.ExitsById(id))
        {
            string ram = args[3];
            string processor = args[4];
            var computer = new Computer(id, ram, processor);
            computerRepository.Update(computer);
        }
        else
        {
            Console.WriteLine($"O computador com Id {id} não existe.");
        }
    }

    if(modelAction == "Delete")
    {
        var id = Convert.ToInt32(args[2]);

       if(computerRepository.ExitsById(id))
        {
            computerRepository.Delete(id);
        }
        else
        {
            Console.WriteLine($"O computador com Id {id} não existe.");
        }        
    }
