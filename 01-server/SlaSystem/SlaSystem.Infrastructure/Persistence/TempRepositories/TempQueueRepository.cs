using Microsoft.EntityFrameworkCore;

namespace SlaSystem.Infrastructure.Persistence.TempRepositories;

public class TempQueueRepository : IQueueRepository
{
    public async Task<Queue> CreateQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        Queue.Queues.Add(queue);
        return queue;
    }

    public async Task<List<Queue>> GetQueuesForRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        return Queue.Queues.Where(x => x.RequestType == requestType).ToList();
    }

    public async Task<List<Queue>> GetQueuesAsync(CancellationToken cancellationToken)
    {
        return Queue.Queues.ToList();
    }

    public async Task<Queue> GetQueueByIdAsync(Guid? queueId, CancellationToken cancellationToken)
    {
        return Queue.Queues.FirstOrDefault(x => x.Id == queueId)!;
    }
}