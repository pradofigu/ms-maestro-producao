namespace BackofficeService.Domain.Invetories.Features;

using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Exceptions;
using Mappings;
using MediatR;

public static class GetInvetory
{
    public sealed record Query(Guid InvetoryId) : IRequest<InvetoryDto>;

    public sealed class Handler : IRequestHandler<Query, InvetoryDto>
    {
        private readonly IInvetoryRepository _invetoryRepository;

        public Handler(IInvetoryRepository invetoryRepository)
        {
            _invetoryRepository = invetoryRepository;
        }

        public async Task<InvetoryDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await _invetoryRepository.GetById(request.InvetoryId, cancellationToken: cancellationToken);
            return result.ToInvetoryDto();
        }
    }
}