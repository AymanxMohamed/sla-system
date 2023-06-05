using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class Password : ValueObject
{
    private Password(string value) => Value = value;
    private string Value { get;  }

    public static Password Create(string password) => new Password(password);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}