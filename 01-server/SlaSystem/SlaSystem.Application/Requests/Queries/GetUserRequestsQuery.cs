namespace SlaSystem.Application.Requests.Queries;

public record GetUserRequestsQuery(Guid UserId) : IQuery<List<Request>>;
