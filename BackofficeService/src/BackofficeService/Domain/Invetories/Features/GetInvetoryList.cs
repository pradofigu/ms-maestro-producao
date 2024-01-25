namespace BackofficeService.Domain.Invetories.Features;

using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Exceptions;
using BackofficeService.Resources;
using Mappings;
using Microsoft.EntityFrameworkCore;
using MediatR;
using QueryKit;
using QueryKit.Configuration;

public static class GetInvetoryList
{
    public sealed record Query(InvetoryParametersDto QueryParameters) : IRequest<PagedList<InvetoryDto>>;

    public sealed class Handler : IRequestHandler<Query, PagedList<InvetoryDto>>
    {
        private readonly IInvetoryRepository _invetoryRepository;

        public Handler(IInvetoryRepository invetoryRepository)
        {
            _invetoryRepository = invetoryRepository;
        }

        public async Task<PagedList<InvetoryDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var collection = _invetoryRepository.Query().AsNoTracking();

            var queryKitConfig = new CustomQueryKitConfiguration();
            var queryKitData = new QueryKitData()
            {
                Filters = request.QueryParameters.Filters,
                SortOrder = request.QueryParameters.SortOrder,
                Configuration = queryKitConfig
            };
            var appliedCollection = collection.ApplyQueryKit(queryKitData);
            var dtoCollection = appliedCollection.ToInvetoryDtoQueryable();

            return await PagedList<InvetoryDto>.CreateAsync(dtoCollection,
                request.QueryParameters.PageNumber,
                request.QueryParameters.PageSize,
                cancellationToken);
        }
    }
}