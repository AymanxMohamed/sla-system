using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Authentication;

public class LoginRequest
{
    public string UserName { get; } = string.Empty;
    public string Password { get; } = string.Empty;
}