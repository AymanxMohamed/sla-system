namespace SlaSystem.Presentation.Api.Contracts.Slas;

public sealed record CreateSlaRequest(RequestType RequestType, Severity Severity, double DurationInHours);
