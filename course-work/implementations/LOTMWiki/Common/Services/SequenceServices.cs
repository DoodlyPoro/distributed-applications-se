using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class SequenceServices : BaseService<Sequence>
{
    public SequenceServices(AppDbContext dbContext) : base(dbContext)
    {
    }
}