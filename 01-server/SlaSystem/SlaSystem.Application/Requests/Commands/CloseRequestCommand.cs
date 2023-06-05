namespace SlaSystem.Application.Requests.Commands;

public sealed record CloseRequestCommand(Guid RequestId) : ICommand;
