using LabManager.Models;

namespace LabManager.Repositories;

public class ComputerRepository
{
    private SystemContext context;

    public ComputerRepository(SystemContext context)
    {
        this.context = context;
    }

    public IEnumerable<Computer> GetAll() => context.Computers.ToList();

    public Computer GetById(int id) => contect.Computers.Find(id);

    public Computer Save(Computer computer)
    {
        context.Add(computer);
        context.SaveChanges();
        return computer;
    }

    public Computer Update(computer computer)
    {
        context.Update(computer);
        context.SaveChanges();
        return computer;
    }

    public void Delete(int id)
    {
        context.Remove(GetById(id));
        context.SaveChanges();
    }
}