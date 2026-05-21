namespace RideSharing.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRideRepository Rides { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
