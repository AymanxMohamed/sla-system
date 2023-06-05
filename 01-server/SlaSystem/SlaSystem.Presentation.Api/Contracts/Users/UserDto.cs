namespace SlaSystem.Presentation.Api.Contracts.Users;

public sealed record UserDto(
    string Id,
    string UserName,
    string Password,
    string Role,
    string Zone,
    string QueueId);
