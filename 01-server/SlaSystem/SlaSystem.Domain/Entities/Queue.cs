using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class Queue : Entity
{
    private readonly List<User> _users = new();

    private Queue(Guid id,QueueName queueName, RequestType requestType) : base(id)
    {
        QueueName = queueName;
        RequestType = requestType;
    }

    public QueueName QueueName { get; }
    public RequestType RequestType { get; }

    internal void AddUser(User user) => _users.Add(user);
    
    public static Queue Create(
        RequestType requestType,
        QueueName queueName)
    {
        return new Queue(new Guid(), queueName, requestType);
    }
    internal void RemoveUser(User user) => _users.Remove(user);
}