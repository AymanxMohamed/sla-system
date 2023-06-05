using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.ValueObjects;

public class QueueName : ValueObject
{
    private QueueName(string value) => Value = value;
    private string Value { get;  }

    public static QueueName Create(string queueName) => new QueueName(queueName);

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}