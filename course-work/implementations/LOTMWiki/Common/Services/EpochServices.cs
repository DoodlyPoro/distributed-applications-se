using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class EpochServices : BaseService<Epoch>
{
    public EpochServices(AppDbContext dbContext) : base(dbContext)
    {
    }
}