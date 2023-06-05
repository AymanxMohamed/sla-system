namespace SlaSystem.Presentation.Api.Contracts.Queues;

public sealed record CreateQueueRequest(RequestType RequestType, string QueueName);
