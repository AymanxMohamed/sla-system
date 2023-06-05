namespace SlaSystem.Presentation.Api.Contracts.Slas;

public class CreateSlaRequest
{
    public RequestType RequestType { get; set; }
    public Severity Severity { get; set; }
    public double DurationInHours { get; set; }
}