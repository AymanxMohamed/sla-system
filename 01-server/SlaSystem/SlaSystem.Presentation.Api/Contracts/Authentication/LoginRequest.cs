using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Authentication;

public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    // public string Zone { get; set; } = string.Empty;
    // public string? QueueId { get; set; }
    // public Role Role { get; set; }
}