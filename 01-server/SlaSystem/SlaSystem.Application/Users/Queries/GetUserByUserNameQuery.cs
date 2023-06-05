namespace SlaSystem.Application.Users.Queries;

public record GetUserByUserName(UserName UserName) : IQuery<User>;
