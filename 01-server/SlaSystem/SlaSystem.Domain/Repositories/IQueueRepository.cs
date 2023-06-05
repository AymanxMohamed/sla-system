using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Repositories;

public interface IQueueRepository
{
    Task<Queue> CreateQueueAsync(Queue queue);
    Task<List<Queue>> GetQueuesForRequestType(RequestType requestType);
    Task<List<Queue>> GetQueues();
}