using EMSI.Airbook.Instraftructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EMSI.Airbook.Infrastructure.Database;

public class UnitOfWork(DbContextOptions<UnitOfWork> options) : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UnitOfWork).Assembly);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql();

    public async Task<int> CommitAsync()
    {
        try
        {
            return await base.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return 0;
        }
    }
}