using SlaSystem.Application.Abstractions.Messaging;

namespace SlaSystem.Application.Requests.Commands;

public sealed record CloseRequestCommand(Guid RequestId) : ICommand;
