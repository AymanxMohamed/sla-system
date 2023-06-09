﻿namespace SlaSystem.Application.Requests.Commands;

public sealed record AssignUserToRequestCommand(Guid OwnerId, Guid RequestId) 
    : ICommand;
