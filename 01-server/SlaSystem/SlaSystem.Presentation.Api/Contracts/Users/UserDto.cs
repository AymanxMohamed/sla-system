namespace SlaSystem.Presentation.Api.Contracts.Users;

public sealed record UserDto(
    string Id,
    string UserName,
    string Password,
    Role Role,
    string Zone,
    string QueueId);
