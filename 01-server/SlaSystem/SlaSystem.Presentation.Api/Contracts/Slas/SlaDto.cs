namespace SlaSystem.Presentation.Api.Contracts.Slas;

public sealed record SlaDto(string Id, string RequestType, string Severity, double DurationInHours);