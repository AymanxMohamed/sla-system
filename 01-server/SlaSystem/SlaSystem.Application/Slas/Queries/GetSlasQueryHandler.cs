namespace SlaSystem.Application.Slas.Queries;

public class GetSlasQueryHandler : IQueryHandler<GetSlasQuery, List<Sla>>
{
    private readonly ISlaRepository _slaRepository;

    public GetSlasQueryHandler(ISlaRepository slaRepository)
    {
        _slaRepository = slaRepository;
    }
    
    public async Task<Result<List<Sla>>> Handle(GetSlasQuery request, CancellationToken cancellationToken)
    {
        return await _slaRepository.GetSlasAsync(cancellationToken);
    }
}