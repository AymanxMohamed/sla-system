using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Domain.Repositories;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<bool> IsUserNameUnique(UserName userName);
    Task<User> GetUserByIdAsync(Guid userId);
    Task<List<User>> GetUsersByQueueAsync(Queue queue);
    Task<List<User>> GetUsersByRoleAsync(Role role);
    Task<List<User>> GetUsersAsync();
}