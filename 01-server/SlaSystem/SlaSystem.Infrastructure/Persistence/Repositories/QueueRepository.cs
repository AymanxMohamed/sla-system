using Microsoft.EntityFrameworkCore;

namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class QueueRepository : IQueueRepository
{
    private ApplicationDbContext _context;

    public QueueRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Queue> CreateQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        return (await _context.Queues.AddAsync(queue, cancellationToken)).Entity;
    }

    public Task<List<Queue>> GetQueuesForRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Queue>> GetQueuesAsync(CancellationToken cancellationToken)
    {
        return await _context.Queues.ToListAsync(cancellationToken: cancellationToken);
    }

    public Task<Queue> GetQueueByIdAsync(Guid? queueId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}