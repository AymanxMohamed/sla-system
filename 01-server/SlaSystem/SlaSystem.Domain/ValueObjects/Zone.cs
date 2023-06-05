using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class Zone : ValueObject
{
    private Zone(string value) => Value = value;
    private string Value { get;  }

    public static Zone Create(string zone) => new Zone(zone);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}