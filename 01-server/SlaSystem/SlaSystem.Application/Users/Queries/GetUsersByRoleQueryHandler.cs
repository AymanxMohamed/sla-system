namespace SlaSystem.Application.Users.Queries;

public class GetUsersByRoleQueryHandler : IQueryHandler<GetUsersByRoleQuery, List<User>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersByRoleQueryHandler(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task<Result<List<User>>> Handle(GetUsersByRoleQuery request, CancellationToken cancellationToken)
    {
        // todo validation for user id
        return await _userRepository.GetUsersByRoleAsync(request.Role, cancellationToken);
    }
}