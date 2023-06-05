using Microsoft.EntityFrameworkCore;

namespace SlaSystem.Infrastructure.Persistence.TempRepositories;

public class TempRequestRepository : IRequestRepository
{
    public async Task AssignUserToRequestAsync(Guid ownerId, Guid requestId, CancellationToken cancellationToken)
    {
        var request = Request.Requests.FirstOrDefault(r => r.Id == requestId);
        var owner = User.Users.FirstOrDefault(u => u.Id == ownerId);
        if (owner == null || request == null) return; 
        request.Assign(owner);
    }

    public async Task CloseRequestAsync(Guid requestId, CancellationToken cancellationToken)
    {
        var request = Request.Requests.FirstOrDefault(r => r.Id == requestId);
        request?.Close();
    }

    public async Task<Request?> GetRequestByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        return Request.Requests.FirstOrDefault(x => x.Id == requestId);
    }

    public async Task<List<Request>> GetRequestsByClientIdAsync(Guid clientId, CancellationToken cancellationToken)
    {
        return Request.Requests.Where(x => x.ClientId == clientId).ToList();
    }

    public async Task<List<Request>> GetRequestsByClientIdAndRequestTypeAsync(Guid clientId, RequestType requestType,
        CancellationToken cancellationToken)
    {
        return Request.Requests.Where(x => x.ClientId == clientId && x.RequestType == requestType).ToList();
    }

    public async Task<List<Request>> GetRequestsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return Request.Requests.Where( x=> x.OwnerId == userId).ToList();
    }

    public async Task<List<Request>> GetRequestsByUserIdAndRequestTypeAsync(Guid userId, RequestType requestType, 
        CancellationToken cancellationToken)
    {
        return Request.Requests.Where( x => x.OwnerId == userId && x.RequestType == requestType).ToList();
    }

    public async Task<List<Request>> GetRequestsByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        return Request.Requests.Where( x => x.RequestType == requestType).ToList();
    }

    public async Task<Request> CreateRequest(Request request, CancellationToken cancellationToken)
    {
        Request.Requests.Add(request);
        return request;
    }
}