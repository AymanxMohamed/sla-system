namespace SlaSystem.Application.Users.Queries;

public record GetUsersByRoleQuery(Role Role) : IQuery<List<User>>;