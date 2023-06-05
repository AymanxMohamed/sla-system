using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
    {
        return user;
    }

    public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken)
    {
        return true;
    }

    public async Task<bool> IsValidPasswordAsync(UserName userName, Password password, CancellationToken cancellationToken)
    {
        return true;
    }

    public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserByUserNameAsync(UserName userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersByQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersByRoleAsync(Role role, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}