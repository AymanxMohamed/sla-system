using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Infrastructure.Repositories;

public class RequestRepository : IRequestRepository
{
    public Task AssignUserToRequestAsync(Guid ownerId, Guid requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CloseRequestAsync(Guid requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Request> GetRequestByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Request>> GetRequestsByClientIdAsync(Guid clientId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Request>> GetRequestsByClientIdAndRequestTypeAsync(Guid clientId, RequestType requestType,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Request>> GetRequestsByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Request>> GetRequestsByUserIdAndRequestTypeAsync(Guid userId, RequestType requestType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Request>> GetRequestsByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Request> CreateRequest(Request request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}