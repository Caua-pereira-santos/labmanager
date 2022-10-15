using LabManager.Models;

namespace LabManager.Repositories;

public class LabRepository
{
    private SystemContext context;

    public LabRepository(SystemContext context)
    {
        this.context = context;
    }

    public IEnumerable<Computer> GetAll() => context.Computers.ToList();

    public Lab GetById(int id) => contect.Labs.Find(id);

    public Lab Save(Lab lab)
    {
        context.Add(lab);
        context.SaveChanges();
        return lab;
    }

    public Lab Update(lab lab)
    {
        context.Update(lab);
        context.SaveChanges();
        return lab;
    }

    public void Delete(int id)
    {
        context.Remove(GetById(id));
        context.SaveChanges();
    }
}