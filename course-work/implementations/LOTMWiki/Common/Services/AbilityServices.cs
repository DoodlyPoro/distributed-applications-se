using System.Linq.Expressions;
using Common.Entity;
using Common.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public class AbilityServices : BaseService<Ability>
{
    public AbilityServices(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public override async Task<List<Ability>> GetAll(
        Expression<Func<Ability, bool>> filter = null,
        string orderBy = null,
        bool sortAsc = false,
        int page = 1,
        int pageSize = int.MaxValue)
    {
        var query = Items
            .Include(x => x.Sequence)
            .AsQueryable();

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

    public override async Task<Ability> GetById(int id)
    {
        return await Items
            .Include(x => x.Sequence)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}