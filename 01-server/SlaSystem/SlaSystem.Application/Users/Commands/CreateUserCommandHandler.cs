using SlaSystem.Domain.Errors;

namespace SlaSystem.Application.Users.Commands;

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, User>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IQueueRepository _queueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, 
        IQueueRepository queueRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _queueRepository = queueRepository;
    }
    
    public async Task<Result<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user;

        var isUserNameUnique = await _userRepository.IsUserNameUniqueAsync(request.UserName, cancellationToken);

        if (!isUserNameUnique)
            return Result.Failure<User>(DomainErrors.User.DuplicateUserName);

        if (request.QueueId != null)
        {
            var queue = await  _queueRepository.GetQueueByIdAsync(request.QueueId, cancellationToken);
            user = User.Create(request.UserName, request.Password, request.Zone, queue);
        }
        else
            user = User.Create(request.UserName, request.Password, request.Zone, null, request.Role);

        var createdUser = await _userRepository.CreateUser(user, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return createdUser;
    }
}