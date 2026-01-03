using EMSI.Airbook.Instraftructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EMSI.Airbook.Infrastructure.Database;

public class RepositoryBase<TDbContext, T, TKey> : ISupportsReadRepository<T, TKey>, ISupportsWriteRepository<T, TKey>
    where T : class
    where TDbContext : DbContext
    where TKey : struct
{
    protected readonly TDbContext Context;
    protected readonly DbSet<T> Set;
    
    protected RepositoryBase(TDbContext context)
    {
        Context = context;
        Set = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(TKey id)
    {
        return await Set.FindAsync(id);
    }

    public async Task<IReadOnlyCollection<T>> GetAllAsync()
    {
        return await Set.AsNoTracking().ToListAsync();
    }

    public IQueryable<T> GetAllQueryable()
    {
        return Set.AsNoTracking();
    }

    public async Task<T> AddAsync(T entity)
    {
        var entry = await Set.AddAsync(entity);
        return entry.Entity;
    }

    public void Update(T entity)
    {
        Set.Update(entity);
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
            return;
        
        Set.Remove(entity);
    }
}