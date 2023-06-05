using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class User : Entity
{
    private User(Guid id, UserName username, Password password, Zone zone, Queue? queue, Role role) 
        : base(id)
    {
        UserName = username;
        Password = password;
        Role = role;
        Zone = zone;
        Queue = queue;
    }
    
    public UserName UserName { get; set; }
    public Password Password { get; set; }
    public Role Role { get; private set; }
    public Zone Zone { get; set; }
    public Queue? Queue { get; private set; }

    public static User Create(UserName username, Password password, Zone zone, Queue? queue, Role role = Role.User)
    {
        var user = new User(Guid.NewGuid(), username, password, zone, queue, role);
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