namespace SlaSystem.Application.Slas.Commands;

public record CreateSlaCommand(RequestType RequestType, Severity Severity, double DurationInHours) 
    : ICommand<Sla>;