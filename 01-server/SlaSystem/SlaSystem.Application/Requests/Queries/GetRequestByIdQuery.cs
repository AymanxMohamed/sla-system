namespace SlaSystem.Application.Requests.Queries;

public record GetRequestByIdQuery(Guid RequestId) : IQuery<Request>;
