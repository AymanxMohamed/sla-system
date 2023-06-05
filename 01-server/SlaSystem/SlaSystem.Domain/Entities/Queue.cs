using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class Queue : Entity
{
    private Queue(Guid id,QueueName queueName, RequestType requestType) : base(id)
    {
        QueueName = queueName;
        RequestType = requestType;
    }

    public QueueName QueueName { get; }
    public RequestType RequestType { get; }
    public List<User> Users { get; } = new();

    internal void AddUser(User user) => Users.Add(user);
    
    public static Queue Create(
        RequestType requestType,
        QueueName queueName)
    {
        return new Queue(Guid.NewGuid(), queueName, requestType);
    }
    internal void RemoveUser(User user) => Users.Remove(user);
}