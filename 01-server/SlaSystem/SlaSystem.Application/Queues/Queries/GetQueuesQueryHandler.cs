namespace SlaSystem.Application.Queues.Queries;

public class GetQueuesQueryHandler : IQueryHandler<GetQueuesQuery, List<Queue>>
{    
    private readonly IQueueRepository _queueRepository;

    public GetQueuesQueryHandler(IQueueRepository queueRepository)
    {
        _queueRepository = queueRepository;
    }
    
    public async Task<Result<List<Queue>>> Handle(GetQueuesQuery request, CancellationToken cancellationToken)
    {
        return await _queueRepository.GetQueuesAsync(cancellationToken);
    }
}