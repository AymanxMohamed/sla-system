using Microsoft.EntityFrameworkCore;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Infrastructure.Persistence.TempRepositories;

public class TempUserRepository : IUserRepository
{
    public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
    {
        User.Users.Add(user);
        return user;
    }

    public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken)
    {
        var user =  User.Users.FirstOrDefault(x => x.UserName == userName.Value);

        return user is null;
    }

    public async Task<bool> IsValidPasswordAsync(UserName userName, Password password, CancellationToken cancellationToken)
    {
        var user =  User.Users.FirstOrDefault(x => x.UserName == userName.Value)!;
        
        return user.UserName == userName.Value &&  user.Password == password.Value;
    }

    public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return User.Users.FirstOrDefault(x => x.Id == userId)!;
    }

    public async Task<User> GetUserByUserNameAsync(UserName userName, CancellationToken cancellationToken)
    {
        return User.Users.FirstOrDefault(x => x.UserName == userName.Value)!;
    }

    public async Task<List<User>> GetUsersByQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        return User.Users.Where(x => x.QueueId == queue.Id).ToList();
    }

    public async Task<List<User>> GetUsersByRoleAsync(Role role, CancellationToken cancellationToken)
    {
        return User.Users.Where(x => x.Role == role).ToList();
    }

    public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
    {
        return User.Users;
    }
}