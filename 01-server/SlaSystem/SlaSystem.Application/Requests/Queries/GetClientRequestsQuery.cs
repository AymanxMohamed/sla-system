namespace SlaSystem.Application.Requests.Queries;

public record GetClientRequestsQuery(Guid ClientId) : IQuery<List<Request>>;
