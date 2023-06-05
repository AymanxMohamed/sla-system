namespace SlaSystem.Application.Users.Queries;

public class GetUserByUserNameQueryHandler : IQueryHandler<GetUserByUserName, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByUserNameQueryHandler(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task<Result<User>> Handle(GetUserByUserName request, CancellationToken cancellationToken)
    {
        // todo validation for user id
        return await _userRepository.GetUserByUserNameAsync(request.UserName, cancellationToken);
    }
}