using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Authentication;

public sealed record LoginRequest(string UserName, string Password);
