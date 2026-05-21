using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class PathwayServices : BaseService<Pathway>
{
    public PathwayServices(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}