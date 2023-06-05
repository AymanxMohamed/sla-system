using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class User : Entity
{
    public static readonly List<User> Users = new();
    private User(Guid id, string userName, string password, string zone, Guid queueId, Role role) 
        : base(id)
    {
        UserName = userName;
        Password = password;
        Role = role;
        Zone = zone;
        QueueId = queueId;
    }
    
    public string UserName { get; set; }
    public string Password { get; set; }
    public Role Role { get; private set; }
    public string Zone { get; set; }
    public Queue? Queue { get; private set; }
    public Guid QueueId { get; set; }

    public List<Request> MyCreatedRequests { get; } = new();
    public List<Request> OwnedRequests { get; } = new();

    public static User Create(UserName username, Password password, Zone zone, Queue queue, Role role = Role.User)
    {
        var user = new User(Guid.NewGuid(), username.Value, password.Value, zone.Value, queue.Id, role)
        {
            Queue = queue
        };
        queue?.AddUser(user);
        return user;
    }

    public void SetRole(Role role) =>  Role = role;

    public void MoveToQueue(Queue? queue)
    {
        Queue?.RemoveUser(this);
        Queue = queue;
        queue?.AddUser(this);
    }
}