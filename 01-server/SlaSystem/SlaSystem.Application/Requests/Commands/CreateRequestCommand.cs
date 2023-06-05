using MediatR;
using SlaSystem.Application.Abstractions.Messaging;
using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Shared;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Application.Requests.Commands;

public sealed record CreateRequestCommand(
    RequestType RequestType,
    Description Description,
    Guid ClientId) : ICommand<Request>;