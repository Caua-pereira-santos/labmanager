using Microsoft.LabManager;

namespace LabManager.Models;

public class SystemContext : DbContext
{
    public DbSet<Computer> Computers {get; set;}
    public Dbset<Lab> Labs {get; set;}

    public SystemContext() { }

    protected override void onConfiguring(DbContextOptionsBuilderoptionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;database=estudante;user=estudante;password=estudante");
    }
}