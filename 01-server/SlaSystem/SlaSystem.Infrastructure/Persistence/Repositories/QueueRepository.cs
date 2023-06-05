namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class QueueRepository : IQueueRepository
{
    public Task<Queue> CreateQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Queue>> GetQueuesForRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Queue>> GetQueuesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Queue> GetQueueByIdAsync(Guid? queueId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}