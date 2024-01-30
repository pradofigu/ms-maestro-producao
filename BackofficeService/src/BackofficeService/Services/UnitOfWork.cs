namespace BackofficeService.Services;

using BackofficeService.Databases;

public interface IUnitOfWork : IBackofficeServiceScopedService
{
    Task<int> CommitChanges(CancellationToken cancellationToken = default);
}

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly BackofficeDbContext _dbContext;

    public UnitOfWork(BackofficeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitChanges(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
