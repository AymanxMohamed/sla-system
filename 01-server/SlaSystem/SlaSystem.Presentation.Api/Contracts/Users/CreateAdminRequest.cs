
namespace SlaSystem.Presentation.Api.Contracts.Users;

public sealed record CreateAdminRequest(string UserName, string Password, string Zone);
