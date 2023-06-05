namespace SlaSystem.Application.Users.Queries;

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public async Task<Result<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        // todo validation for user id
        return await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
    }
}