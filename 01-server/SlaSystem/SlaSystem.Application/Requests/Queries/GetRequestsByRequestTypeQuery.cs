namespace SlaSystem.Application.Requests.Queries;

public record GetRequestsByRequestTypeQuery(RequestType RequestType) : IQuery<List<Request>>;
