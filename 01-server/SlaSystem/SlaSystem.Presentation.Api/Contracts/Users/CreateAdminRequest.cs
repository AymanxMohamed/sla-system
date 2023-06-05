
namespace SlaSystem.Presentation.Api.Contracts.Users;

public class CreateAdminRequest
{
    public string UserName { get; } = string.Empty;
    public string Password { get; } = string.Empty;
    public string Zone { get; set; } = string.Empty;
}