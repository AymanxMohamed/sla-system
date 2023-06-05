namespace SlaSystem.Presentation.Api.Contracts.Queues;

public sealed record QueueDto(string Id, string QueueName, string RequestType, List<UserDto> Users);