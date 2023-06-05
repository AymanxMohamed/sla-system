namespace SlaSystem.Application.Users.Queries;

public record GetUserByIdQuery(Guid UserId) : IQuery<User>;