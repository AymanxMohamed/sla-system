using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Entities;

public class User : Entity
{
    public UserName UserName { get; set; } = UserName.Create(string.Empty);
    public Password Password { get; set; } = Password.Create(string.Empty);
    public Role Role { get; set; } = Role.Client;
    public Zone Zone { get; set; } = Zone.Create(string.Empty);
    public Queue Queue { get; set; }
}