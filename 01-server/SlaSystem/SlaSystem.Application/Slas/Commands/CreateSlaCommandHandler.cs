namespace SlaSystem.Application.Slas.Commands;

public class CreateSlaCommandHandler : ICommandHandler<CreateSlaCommand, Sla>
{
    private readonly ISlaRepository _slaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateSlaCommandHandler(ISlaRepository slaRepository, IUnitOfWork unitOfWork)
    {
        _slaRepository = slaRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<Sla>> Handle(CreateSlaCommand request, CancellationToken cancellationToken)
    {
        var sla = Sla.Create(request.RequestType, request.Severity, request.DurationInHours);
        
        var createdSla = await _slaRepository.CreateSlaAsync(sla, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return createdSla;
    }
}