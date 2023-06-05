using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Repositories;

public interface IRequestRepository
{
    Task AssignUserToRequestAsync(Guid ownerId, Guid requestId);
    Task CloseRequestAsync(Guid requestId);
    Task<Request> GetRequestByIdAsync(Guid requestId);
    Task<List<Request>> GetRequestsByClientIdAsync(Guid clientId);
    Task<List<Request>> GetRequestsByClientIdAndRequestTypeAsync(Guid clientId, RequestType requestType);
    Task<List<Request>> GetRequestsByRequestTypeAsync(RequestType requestType);
    Task<Request> CreateRequest(Request request);
}