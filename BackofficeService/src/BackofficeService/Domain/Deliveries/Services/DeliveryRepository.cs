namespace BackofficeService.Domain.Deliveries.Services;

using BackofficeService.Domain.Deliveries;
using BackofficeService.Databases;
using BackofficeService.Services;

public interface IDeliveryRepository : IGenericRepository<Delivery>
{
}

public sealed class DeliveryRepository : GenericRepository<Delivery>, IDeliveryRepository
{
    private readonly BackofficeDbContext _dbContext;

    public DeliveryRepository(BackofficeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
