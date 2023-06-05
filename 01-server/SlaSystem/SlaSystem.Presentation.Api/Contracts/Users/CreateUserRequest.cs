using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Users;

public sealed record CreateUserRequest(string UserName, string Password, string Zone, string QueueId);
