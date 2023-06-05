using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Repositories;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Requests.Commands;

public class CreateRequestCommandHandler : ICommandHandler<CreateRequestCommand, Request>
{
    private readonly IRequestRepository _requestRepository;
    private readonly ISlaRepository _slaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateRequestCommandHandler(IUnitOfWork unitOfWork, IRequestRepository requestRepository, ISlaRepository slaRepository)
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
        _slaRepository = slaRepository;
    }

    public async Task<Result<Request>> Handle(CreateRequestCommand req, CancellationToken cancellationToken)
    {
        var sla = await _slaRepository.GetSlasByRequestTypeAsync(req.RequestType, cancellationToken);
        var request = Request.Create(req.RequestType, req.Description, sla, req.ClientId);
        
        var createdRequest = await _requestRepository.CreateRequest(request, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return createdRequest;
    }
}