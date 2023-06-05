using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class Queue : Entity
{
    public static readonly List<Queue> Queues = new();
    private Queue(Guid id, string queueName, RequestType requestType) : base(id)
    {
        QueueName = queueName;
        RequestType = requestType;
    }

    public string QueueName { get; set; }
    public RequestType RequestType { get; }
    public List<User> Users { get; } = new();

    public void AddUser(User user) => Users.Add(user);
    
    public static Queue Create(
        RequestType requestType,
        QueueName queueName)
    {
        return new Queue(Guid.NewGuid(), queueName.Value, requestType);
    }
    public void RemoveUser(User user) => Users.Remove(user);
}