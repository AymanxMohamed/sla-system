using SlaSystem.Domain.Entities;
using SlaSystem.Domain.Enums;

namespace SlaSystem.Domain.Repositories;

public interface ISlaRepository
{
    Task<List<Sla>> GetSlasAsync();
    Task<List<Sla>> GetSlasByRequestTypeAsync(RequestType requestType);
    Task<Sla> GetSlaByIdAsync();
    Task<Sla> CreateSlaAsync();
}