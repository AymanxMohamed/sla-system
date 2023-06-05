namespace SlaSystem.Application.Requests.Commands;

public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Request>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISlaRepository _slaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRequestCommandHandler(IUnitOfWork unitOfWork, IRequestRepository requestRepository
        , ISlaRepository slaRepository, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
        _slaRepository = slaRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<Request>> Handle(CreateRequestCommand req, CancellationToken cancellationToken)
    {
        var sla = await _slaRepository.GetSlasByRequestTypeAsync(req.RequestType, cancellationToken);
        var client = await _userRepository.GetUserByIdAsync(req.ClientId, cancellationToken);
        var request = Request.Create(req.RequestType, req.Description, sla, client);
        
        var createdRequest = await _requestRepository.CreateRequest(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return createdRequest;
    }
}