namespace SlaSystem.Application.Requests.Queries;

public class GetUserRequestsQueryHandler : IQueryHandler<GetUserRequestsQuery, List<Request>>
{
    private readonly IRequestRepository _requestRepository;

    public GetUserRequestsQueryHandler(IRequestRepository requestRepository) =>
        _requestRepository = requestRepository;
    
    public async Task<Result<List<Request>>> Handle(GetUserRequestsQuery request, CancellationToken cancellationToken)
    {
       return await _requestRepository.GetRequestsByUserIdAsync(request.UserId, 
            cancellationToken);
    }
}