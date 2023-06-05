using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Shared;

public static class Utilities
{
    public static string MapRole(Role role)
    {
        return role switch
        {
            Role.Admin => "Admin",
            Role.User => "User",
            Role.Client => "Client",
            _ => throw new ArgumentOutOfRangeException(nameof(role), role, null)
        };
    }
}