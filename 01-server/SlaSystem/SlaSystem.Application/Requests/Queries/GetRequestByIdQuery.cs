using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;

namespace SlaSystem.Application.Requests.Queries;

public record GetRequestByIdQuery(Guid RequestId) : IQuery<Request>;
