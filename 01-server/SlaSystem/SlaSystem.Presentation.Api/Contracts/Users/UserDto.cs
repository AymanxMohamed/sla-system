using SlaSystem.Domain.Enums;

namespace SlaSystem.Presentation.Api.Contracts.Users;

public class UserDto
{
    public string UserName { get; }
    public string Role { get; }
    public string Zone { get; }
    public string Id { get; }

    private UserDto(User user)
    {
        UserName = user.UserName.Value;
        Role = Utilities.MapRole(user.Role);
        Zone = user.Zone.Value;
        Id = user.Id.ToString();
    }

    public static UserDto Create(User user)
    {
        return new UserDto(user);
    }
    
}