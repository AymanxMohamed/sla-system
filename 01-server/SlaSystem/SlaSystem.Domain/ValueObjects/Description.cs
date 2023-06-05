using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class Description : ValueObject
{
    private Description(string value) => Value = value;
    public string Value { get;  }

    public static Description Create(string description) => new Description(description);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}