using Common.Entity;
using Common.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public class BaseService<T> where T : BaseEntity
{
    protected readonly AppDbContext DbContext;
    protected readonly DbSet<T> Items;

    protected BaseService(AppDbContext dbContext)
    {
        DbContext = dbContext;
        Items = DbContext.Set<T>();
    }

    public async Task<List<T>> GetAll()
    {
        return await Items.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Save(T item)
    {
        if (item.Id > 0) Items.Update(item);
        else Items.Add(item);
        
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        Items.Remove(item);
        
        await DbContext.SaveChangesAsync();
    }
}