using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Users;

public class CreateUserRequest
{
    public string UserName { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
    public string QueueId { get; set; } = string.Empty;
}