namespace SlaSystem.Application.Requests.Commands;

public class AssignUserToRequestCommandHandler : ICommandHandler<AssignUserToRequestCommand>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AssignUserToRequestCommandHandler(IUnitOfWork unitOfWork, IRequestRepository requestRepository)
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
    }
    
    public async Task<Result> Handle(AssignUserToRequestCommand request, CancellationToken cancellationToken)
    {
        await _requestRepository.AssignUserToRequestAsync(request.OwnerId, request.RequestId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}

