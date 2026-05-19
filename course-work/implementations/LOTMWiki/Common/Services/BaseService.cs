using Common.Entity;
using Common.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public class BaseService<T> where T : BaseEntity
{
    private DbContext DbContext { get; set; }
    private DbSet<T> Items { get; set; }

    protected BaseService()
    {
        DbContext = new AppDbContext();
        Items = DbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await Items.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async void Save(T item)
    {
        if (item.Id > 0) Items.Update(item);
        else Items.Add(item);
        
        await DbContext.SaveChangesAsync();
    }

    public async void Delete(T item)
    {
        Items.Remove(item);
        
        await DbContext.SaveChangesAsync();
    }
}