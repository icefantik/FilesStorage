using Microsoft.EntityFrameworkCore;

namespace FilesStorage.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Users> Users { get; set; }
    public ApplicationContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(""); // строка подключения
    }
}
