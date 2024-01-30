namespace BackofficeService.Domain.Invetories.Features;

using BackofficeService.Domain.Invetories;
using BackofficeService.Domain.Invetories.Dtos;
using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Services;
using BackofficeService.Domain.Invetories.Models;
using BackofficeService.Exceptions;
using Mappings;
using MediatR;

public static class UpdateInvetory
{
    public sealed record Command(Guid InvetoryId, InvetoryForUpdateDto UpdatedInvetoryData) : IRequest;

    public sealed class Handler : IRequestHandler<Command>
    {
        private readonly IInvetoryRepository _invetoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Handler(IInvetoryRepository invetoryRepository, IUnitOfWork unitOfWork)
        {
            _invetoryRepository = invetoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var invetoryToUpdate = await _invetoryRepository.GetById(request.InvetoryId, cancellationToken: cancellationToken);
            var invetoryToAdd = request.UpdatedInvetoryData.ToInvetoryForUpdate();
            invetoryToUpdate.Update(invetoryToAdd);

            _invetoryRepository.Update(invetoryToUpdate);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}