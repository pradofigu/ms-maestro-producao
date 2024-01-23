namespace BackofficeService.Domain.Invetories.Features;

using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Models;
using BackofficeService.Services;
using BackofficeService.Exceptions;
using Mappings;
using MediatR;

public static class AddInvetory
{
    public sealed record Command(InvetoryForCreationDto InvetoryToAdd) : IRequest<InvetoryDto>;

    public sealed class Handler : IRequestHandler<Command, InvetoryDto>
    {
        private readonly IInvetoryRepository _invetoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IInvetoryRepository invetoryRepository, IUnitOfWork unitOfWork)
        {
            _invetoryRepository = invetoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<InvetoryDto> Handle(Command request, CancellationToken cancellationToken)
        {
            var invetoryToAdd = request.InvetoryToAdd.ToInvetoryForCreation();
            var invetory = Invetory.Create(invetoryToAdd);

            await _invetoryRepository.Add(invetory, cancellationToken);
            await _unitOfWork.CommitChanges(cancellationToken);

            return invetory.ToInvetoryDto();
        }
    }
}