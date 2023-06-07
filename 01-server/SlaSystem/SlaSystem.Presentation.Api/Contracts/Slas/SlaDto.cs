namespace SlaSystem.Presentation.Api.Contracts.Slas;

public sealed record SlaDto(string Id, RequestType RequestType, Severity Severity, double DurationInHours);