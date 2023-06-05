using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;

namespace SlaSystem.Application.Requests.Queries;

public record GetUserRequestsQuery(Guid UserId) : IQuery<List<Request>>;
