using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.Entities;

public class Queue : Entity
{
    public string Name { get; set; } = string.Empty;
    public RequestType RequestType { get; set; } = RequestType.Invoice;
}