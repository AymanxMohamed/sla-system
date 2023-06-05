using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.Entities;

public class Sla : Entity
{
    public RequestType RequestType { get; set; } = RequestType.Invoice;
    public Severity Severity { get; set; } = Severity.Low;
    public double DurationInHours { get; set; }
}