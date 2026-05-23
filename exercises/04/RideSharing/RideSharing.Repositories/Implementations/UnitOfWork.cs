using RideSharing.Data;
using RideSharing.Repositories.Interfaces;

namespace RideSharing.Repositories.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly IDbContext _context;
    private IRideRepository? _rides;

    public UnitOfWork(IDbContext context)
    {
        _context = context;
    }

    public IRideRepository Rides
        => _rides ??= new RideRepository(_context);

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);

    public void Dispose()
    {
        if (_context is IDisposable disposable)
            disposable.Dispose();
    }
}
