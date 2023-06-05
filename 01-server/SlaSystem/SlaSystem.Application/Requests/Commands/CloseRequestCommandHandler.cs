using MediatR;
using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Repositories;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Requests.Commands;

public class CloseRequestCommandHandler : ICommandHandler<CloseRequestCommand>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CloseRequestCommandHandler(IUnitOfWork unitOfWork, IRequestRepository requestRepository)
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
    }
    public async Task<Result> Handle(CloseRequestCommand request, CancellationToken cancellationToken)
    {
        await _requestRepository.CloseRequestAsync(request.RequestId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}