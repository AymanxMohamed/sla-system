using Microsoft.EntityFrameworkCore;
using SlaSystem.Domain.ValueObjects;

namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> CreateUser(User user, CancellationToken cancellationToken)
    {
        return (await _context.Users.AddAsync(user, cancellationToken)).Entity;
    }

    public async Task<bool> IsUserNameUniqueAsync(UserName userName, CancellationToken cancellationToken)
    {
        var user =  (await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName.Value,
            cancellationToken: cancellationToken))!;

        return user.UserName == userName.Value;
    }

    public async Task<bool> IsValidPasswordAsync(UserName userName, Password password, CancellationToken cancellationToken)
    {
        var user =  (await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName.Value,
            cancellationToken: cancellationToken))!;
        
        return user.UserName == userName.Value &&  user.Password == password.Value;
    }

    public async Task<User> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return (await _context.Users.FirstOrDefaultAsync(x => x.Id == userId,
            cancellationToken: cancellationToken))!;
    }

    public async Task<User> GetUserByUserNameAsync(UserName userName, CancellationToken cancellationToken)
    {
        return (await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName.Value,
            cancellationToken: cancellationToken))!;
    }

    public async Task<List<User>> GetUsersByQueueAsync(Queue queue, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(x => x.Queue == queue).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<User>> GetUsersByRoleAsync(Role role, CancellationToken cancellationToken)
    {
        return await _context.Users.Where(x => x.Role == role).
            ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<User>> GetUsersAsync(CancellationToken cancellationToken)
    {
        return await _context.Users.ToListAsync(cancellationToken: cancellationToken);
    }
}