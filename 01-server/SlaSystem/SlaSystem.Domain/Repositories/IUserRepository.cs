using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user, CancellationToken cancellationToken);
    Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken);
    Task<bool> IsValidPasswordAsync(UserName userName, Password password, CancellationToken cancellationToken);
    Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<User> GetUserByUserNameAsync(UserName userName, CancellationToken cancellationToken);
    Task<List<User>> GetUsersByQueueAsync(Queue queue, CancellationToken cancellationToken);
    Task<List<User>> GetUsersByRoleAsync(Role role, CancellationToken cancellationToken);
    Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);
}