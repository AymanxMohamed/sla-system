namespace SlaSystem.Presentation.Api.Contracts.Queues;

public class CreateQueueRequest
{
    public RequestType RequestType { get; set; }
    public string QueueName { get; set; } = string.Empty;
}