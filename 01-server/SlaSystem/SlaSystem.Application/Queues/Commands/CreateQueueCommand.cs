namespace SlaSystem.Application.Queues.Commands;

public record CreateQueueCommand(RequestType RequestType, QueueName QueueName) 
    : ICommand<Queue>;