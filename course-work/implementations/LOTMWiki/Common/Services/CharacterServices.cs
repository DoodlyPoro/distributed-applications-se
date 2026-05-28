using System.Linq.Expressions;
using Common.Entity;
using Common.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Common.Services;

public class CharacterServices : BaseService<Character>
{
    public CharacterServices(AppDbContext dbContext) : base(dbContext)
    {
    }
    
    public override async Task<List<Character>> GetAll(
        Expression<Func<Character, bool>> filter = null,
        string orderBy = null,
        bool sortAsc = false,
        int page = 1,
        int pageSize = int.MaxValue)
    {
        var query = Items
            .Include(x => x.Sequence)
            .Include(x => x.Pathway)
            .Include(x => x.Epoch)
            .AsQueryable();

        if (filter != null)
            query = query.Where(filter);

        if (!string.IsNullOrEmpty(orderBy))
        {
            query = sortAsc
                ? query.OrderBy(e => EF.Property<object>(e, orderBy))
                : query.OrderByDescending(e => EF.Property<object>(e, orderBy));
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public override async Task<Character> GetById(int id)
    {
        return await Items
            .Include(x => x.Sequence)
            .Include(x => x.Pathway)
            .Include(x => x.Epoch)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}