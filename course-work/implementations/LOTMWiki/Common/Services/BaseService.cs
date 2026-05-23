using System.Linq.Expressions;
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
        Items = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null, string orderBy = null, bool sortAsc = false, int page = 1, int pageSize = int.MaxValue)
    {
        var query = Items.AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        if (!string.IsNullOrEmpty(orderBy))
        {
            if (sortAsc)
                query = query.OrderBy(e => EF.Property<object>(e, orderBy));
            else
                query = query.OrderByDescending(e => EF.Property<object>(e, orderBy));
        }

        query = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize);

        return await query.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await Items.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Save(T item)
    {
        if (item.Id > 0) Items.Update(item);
        else await Items.AddAsync(item);
        
        await DbContext.SaveChangesAsync();
    }

    public async Task Delete(T item)
    {
        Items.Remove(item);
        
        await DbContext.SaveChangesAsync();
    }

    public async Task<int> Count(Expression<Func<T, bool>> filter = null)
    {
        var query = Items.AsQueryable();
        if (filter != null)
            query = query.Where(filter);

        return await query.CountAsync();
    }
}