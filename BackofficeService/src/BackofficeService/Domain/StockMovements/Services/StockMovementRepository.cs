namespace BackofficeService.Domain.StockMovements.Services;

using BackofficeService.Domain.StockMovements;
using BackofficeService.Databases;
using BackofficeService.Services;

public interface IStockMovementRepository : IGenericRepository<StockMovement>
{
}

public sealed class StockMovementRepository : GenericRepository<StockMovement>, IStockMovementRepository
{
    private readonly BackofficeDbContext _dbContext;

    public StockMovementRepository(BackofficeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
