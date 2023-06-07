namespace SlaSystem.Presentation.Api.Contracts.Queues;

public sealed record QueueDto(string Id, string QueueName, RequestType RequestType, List<UserDto> Users);