using RideSharing.Data;
using RideSharing.Data.Entities;
using RideSharing.Repositories.Interfaces;

namespace RideSharing.Repositories.Implementations
{
    public class RideRepository : Repository<RideEntity>, IRideRepository
    {
        public RideRepository(IDbContext context) : base(context)
        { }
    }
}
