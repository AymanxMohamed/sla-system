using System.Data.Entity;

namespace SlaSystem.Infrastructure.Persistence.TempRepositories;

public class TempSlaRepository : ISlaRepository
{
    public async Task<List<Sla>> GetSlasAsync(CancellationToken cancellationToken)
    {
        return Sla.Slas;
    }

    public async Task<Sla> GetSlasByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        return Sla.Slas.FirstOrDefault(x => x.RequestType == requestType)!;
    }

    public async Task<Sla> GetSlaByIdAsync(Guid slaId,CancellationToken cancellationToken)
    {
        return Sla.Slas.FirstOrDefault(x => x.Id == slaId)!;
    }

    public async Task<Sla> CreateSlaAsync(Sla sla, CancellationToken cancellationToken)
    {
        Sla.Slas.Add(sla);
        return sla;
    }
}