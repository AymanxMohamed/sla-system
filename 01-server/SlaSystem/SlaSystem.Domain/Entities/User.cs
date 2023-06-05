using SlaSystem.Domain.Enums;
using SlaSystem.Domain.Primitives;

namespace SlaSystem.Domain.Entities;

public class User : Entity
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.Client;
    public string Zone { get; set; } = string.Empty;



}