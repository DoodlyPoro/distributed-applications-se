using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class AbilityServices : BaseService<Ability>
{
    public AbilityServices(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}