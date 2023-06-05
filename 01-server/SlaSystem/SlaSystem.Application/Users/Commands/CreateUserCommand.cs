namespace SlaSystem.Application.Users.Commands;

public sealed record CreateUserCommand(UserName UserName, Password Password, Zone Zone, Guid? QueueId, Role Role) : 
    ICommand<User>;