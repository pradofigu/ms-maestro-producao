namespace BackofficeService.Domain.Invetories.Features;

using BackofficeService.Domain.Invetories.Services;
using BackofficeService.Services;
using BackofficeService.Exceptions;
using MediatR;

public static class DeleteInvetory
{
    public sealed record Command(Guid InvetoryId) : IRequest;

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
            var recordToDelete = await _invetoryRepository.GetById(request.InvetoryId, cancellationToken: cancellationToken);
            _invetoryRepository.Remove(recordToDelete);
            await _unitOfWork.CommitChanges(cancellationToken);
        }
    }
}