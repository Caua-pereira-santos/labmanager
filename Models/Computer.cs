namespace LabManager.Models;


public class Computer
{
    public int Id {get; set;}
    public string Ram {get; set;}
    public string Processor {get; set;}

    public Computer() { }

    public Computer(int id, string ram, string processor)
   {
       Id = id;
       Ram = ram;
       Processor = processor;
   }
   
}

public class Lab
{
    public int Id {get; set;}
    public int Number {get; set;}
    public string Name {get; set;}
    public string Block {get; set;}

    public Lab() { }

    public Lab(int id, int number, string name, string block)
    {
        Id = id;
        Number = number;
        Name = name;
        Block = block;
    }
}



