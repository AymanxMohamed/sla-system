using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class User : Entity
{
    private User(UserName username, Password password, Role role, Zone zone, Queue queue)
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
    public Queue Queue { get; private set; }

    public static User Create(UserName username, Password password, Role role, Zone zone, Queue queue)
    {
        var user = new User(username, password, role, zone, queue);
        queue.AddUser(user);
        return user;
    }

    public void SetRole(Role role) =>  Role = role;

    public void MoveToQueue(Queue queue)
    {
        Queue.RemoveUser(this);
        Queue = queue;
        queue.AddUser(this);
    }
}