﻿using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Repositories;

public interface IQueueRepository
{
    Task<Queue> CreateQueueAsync(Queue queue, CancellationToken cancellationToken);
    Task<List<Queue>> GetQueuesForRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken);
    Task<List<Queue>> GetQueuesAsync(CancellationToken cancellationToken);
    Task<Queue> GetQueueByIdAsync(Guid? queueId, CancellationToken cancellationToken);
}