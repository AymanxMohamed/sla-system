using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Repositories;

public interface IRequestRepository
{
    Task AssignUserToRequestAsync(Guid ownerId, Guid requestId, CancellationToken cancellationToken);
    Task CloseRequestAsync(Guid requestId, CancellationToken cancellationToken);
    Task<Request> GetRequestByIdAsync(Guid requestId, CancellationToken cancellationToken);
    Task<List<Request>> GetRequestsByClientIdAsync(Guid clientId, CancellationToken cancellationToken);
    Task<List<Request>> GetRequestsByClientIdAndRequestTypeAsync(Guid clientId, RequestType requestType, CancellationToken cancellationToken);
    Task<List<Request>> GetRequestsByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<List<Request>> GetRequestsByUserIdAndRequestTypeAsync(Guid userId, RequestType requestType, CancellationToken cancellationToken);
    Task<List<Request>> GetRequestsByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken);
    Task<Request> CreateRequest(Request request, CancellationToken cancellationToken);
}