using Common.Entity;
using Common.Persistance;

namespace Common.Services;

public class CharacterServices : BaseService<Character>
{
    public CharacterServices(AppDbContext dbContext) : base(dbContext)
    {
        
    }
}