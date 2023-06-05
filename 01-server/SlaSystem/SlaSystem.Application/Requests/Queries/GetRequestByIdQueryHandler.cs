using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Repositories;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Requests.Queries;

public class GetRequestByIdQueryHandler : IQueryHandler<GetRequestByIdQuery, Request>
{
    private readonly IRequestRepository _requestRepository;

    public GetRequestByIdQueryHandler(IRequestRepository requestRepository) =>
        _requestRepository = requestRepository;
    
    public async Task<Result<Request>> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
    {
       return await _requestRepository.GetRequestByIdAsync(request.RequestId, 
            cancellationToken);
    }
}