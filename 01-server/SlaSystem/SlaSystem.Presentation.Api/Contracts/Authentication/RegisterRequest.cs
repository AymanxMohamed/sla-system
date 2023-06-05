namespace SlaSystem.Presentation.Api.Contracts.Authentication;

public sealed record RegisterRequest(string UserName, string Password, string Zone);
