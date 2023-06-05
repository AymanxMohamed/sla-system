using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Repositories;

public interface ISlaRepository
{
    Task<List<Sla>> GetSlasAsync(CancellationToken cancellationToken);
    Task<Sla> GetSlasByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken);
    Task<Sla> GetSlaByIdAsync(CancellationToken cancellationToken);
    Task<Sla> CreateSlaAsync(Sla sla, CancellationToken cancellationToken);
}