using SlaSystem.Application.Abstractions.Messaging;

namespace SlaSystem.Application.Requests.Commands;

public sealed record AssignUserToRequestCommand(Guid OwnerId, Guid RequestId, CancellationToken CancellationToken) 
    : ICommand;
