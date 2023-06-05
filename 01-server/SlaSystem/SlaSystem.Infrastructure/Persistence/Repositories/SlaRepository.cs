namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class SlaRepository : ISlaRepository
{
    public Task<List<Sla>> GetSlasAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Sla> GetSlasByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Sla> GetSlaByIdAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Sla> CreateSlaAsync(Sla sla, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}