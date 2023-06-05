
namespace SlaSystem.Application.Authentication.Commands;

public class LoginCommandHandler : ICommandHandler<LoginCommand, User>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var isUserNameExist = !await _userRepository.IsUserNameUniqueAsync(request.UserName, cancellationToken);

        if (!isUserNameExist)
            return Result.Failure<User>(DomainErrors.User.InvalidUserName);
        
        var isValidPassword =
            await _userRepository.IsValidPasswordAsync(request.UserName, request.Password, cancellationToken);

        if (!isValidPassword)
            return Result.Failure<User>(DomainErrors.User.InvalidPassword);

        return await _userRepository.GetUserByUserNameAsync(request.UserName, cancellationToken);
    }
}