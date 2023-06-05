namespace SlaSystem.Application.Queues.Commands;

public class CreateQueueCommandHandler : ICommandHandler<CreateQueueCommand, Queue>
{
    private readonly IQueueRepository _queueRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateQueueCommandHandler(IQueueRepository slaRepository, IUnitOfWork unitOfWork)
    {
        _queueRepository = slaRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Queue>> Handle(CreateQueueCommand request, CancellationToken cancellationToken)
    {
        var queue = Queue.Create(request.RequestType, request.QueueName);
        
        var createdQueue = await _queueRepository.CreateQueueAsync(queue, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return createdQueue;
    }
}