namespace BackofficeService.Domain.Invetories.Services;

using BackofficeService.Domain.Invetories;
using BackofficeService.Databases;
using BackofficeService.Services;

public interface IInvetoryRepository : IGenericRepository<Invetory>
{
}

public sealed class InvetoryRepository : GenericRepository<Invetory>, IInvetoryRepository
{
    private readonly BackofficeDbContext _dbContext;

    public InvetoryRepository(BackofficeDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
