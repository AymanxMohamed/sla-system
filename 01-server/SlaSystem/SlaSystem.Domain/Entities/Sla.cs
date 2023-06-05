using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.Entities;

public class Sla : Entity
{
    private Sla(Guid id,RequestType requestType, Severity severity, double durationInHours) : base(id)
    {
        RequestType = requestType;
        Severity = severity;
        DurationInHours = durationInHours;
    }
    public RequestType RequestType { get; private set; }
    public Severity Severity { get; private set; }
    public double DurationInHours { get; private set; }

    public void SetRequestType(RequestType requestType) => RequestType = requestType;
    public void SetSeverity(Severity severity) => Severity = severity;
    public void SetDuration(double durationInHours) => DurationInHours = durationInHours;
    
    public static Sla Create(
        RequestType requestType, Severity severity, double durationInHours) =>
        new Sla(Guid.NewGuid(), requestType, severity, durationInHours);
}