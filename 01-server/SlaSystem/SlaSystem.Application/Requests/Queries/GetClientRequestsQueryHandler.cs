using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Repositories;
using SlaSystem.Domain.Shared;

namespace SlaSystem.Application.Requests.Queries;

public class GetClientRequestsQueryHandler : IQueryHandler<GetClientRequestsQuery, List<Request>>
{
    private readonly IRequestRepository _requestRepository;

    public GetClientRequestsQueryHandler(IRequestRepository requestRepository) =>
        _requestRepository = requestRepository;
    
    public async Task<Result<List<Request>>> Handle(GetClientRequestsQuery request, CancellationToken cancellationToken)
    {
       return await _requestRepository.GetRequestsByClientIdAsync(request.ClientId, 
            cancellationToken);
    }
}