using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class UserServices : BaseService<User>
{
    public UserServices(AppDbContext dbContext) : base(dbContext)
    {
    }
}