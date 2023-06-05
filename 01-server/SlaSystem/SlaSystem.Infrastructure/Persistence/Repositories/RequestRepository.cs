using Microsoft.EntityFrameworkCore;

namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class RequestRepository : IRequestRepository
{
    private readonly ApplicationDbContext _context;

    public RequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AssignUserToRequestAsync(Guid ownerId, Guid requestId, CancellationToken cancellationToken)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId,
            cancellationToken: cancellationToken);
        if (request == null) return;
        request.Assign(ownerId);
        _context.Requests.Update(request);
    }

    public async Task CloseRequestAsync(Guid requestId, CancellationToken cancellationToken)
    {
        var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId,
            cancellationToken: cancellationToken);
        if (request == null) return;
        request.Close();
        _context.Requests.Update(request);
    }

    public async Task<Request> GetRequestByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        
        return (await _context.Requests.FirstOrDefaultAsync(x => x.Id == requestId,
            cancellationToken: cancellationToken))!;
    }

    public async Task<List<Request>> GetRequestsByClientIdAsync(Guid clientId, CancellationToken cancellationToken)
    {
        return await _context.Requests.Where(x => x.ClientId == clientId).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Request>> GetRequestsByClientIdAndRequestTypeAsync(Guid clientId, RequestType requestType,
        CancellationToken cancellationToken)
    {
        return await _context.Requests.Where(x => x.ClientId == clientId && x.RequestType == requestType).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Request>> GetRequestsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Requests.Where(x => x.OwnerId == userId).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Request>> GetRequestsByUserIdAndRequestTypeAsync(Guid userId, RequestType requestType, 
        CancellationToken cancellationToken)
    {
        return await _context.Requests.Where(x => x.OwnerId == userId && x.RequestType == requestType).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<Request>> GetRequestsByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        return await _context.Requests.Where(x => x.RequestType == requestType).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Request> CreateRequest(Request request, CancellationToken cancellationToken)
    {
        var created = await _context.AddAsync(request, cancellationToken);
        return created.Entity;
    }
}