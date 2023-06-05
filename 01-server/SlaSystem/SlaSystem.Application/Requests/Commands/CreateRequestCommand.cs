namespace SlaSystem.Application.Requests.Commands;

public sealed record CreateRequestCommand(
    RequestType RequestType,
    Description Description,
    Guid ClientId) : ICommand<Request>;