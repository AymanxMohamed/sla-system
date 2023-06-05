using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class Password : ValueObject
{
    public const int MaxLength = 50;
    private Password(string value) => Value = value;
    private string Value { get;  }

    public static Password Create(string username)
    {
        return new Password(username);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}