namespace SlaSystem.Application.Requests.Queries;

public class GetRequestsByRequestTypeQueryHandler : IQueryHandler<GetRequestsByRequestTypeQuery, List<Request>>
{
    private readonly IRequestRepository _requestRepository;

    public GetRequestsByRequestTypeQueryHandler(IRequestRepository requestRepository) =>
        _requestRepository = requestRepository;
    
    public async Task<Result<List<Request>>> Handle(GetRequestsByRequestTypeQuery request, CancellationToken cancellationToken)
    {
       return await _requestRepository.GetRequestsByRequestTypeAsync(request.RequestType, 
            cancellationToken);
    }
}