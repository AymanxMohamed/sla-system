using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Repositories;

public interface IQueueRepository
{
    Task<Queue> CreateQueueAsync(Queue queue, CancellationToken cancellationToken);
    Task<List<Queue>> GetQueuesForRequestType(RequestType requestType, CancellationToken cancellationToken);
    Task<List<Queue>> GetQueues(CancellationToken cancellationToken);
}