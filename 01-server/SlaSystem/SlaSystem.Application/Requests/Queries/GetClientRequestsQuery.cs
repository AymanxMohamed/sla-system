using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;

namespace SlaSystem.Application.Requests.Queries;

public record GetClientRequestsQuery(Guid ClientId) : IQuery<List<Request>>;
