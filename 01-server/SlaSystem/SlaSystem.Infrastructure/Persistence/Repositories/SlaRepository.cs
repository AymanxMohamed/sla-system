using System.Data.Entity;

namespace SlaSystem.Infrastructure.Persistence.Repositories;

public class SlaRepository : ISlaRepository
{
    private readonly ApplicationDbContext _context;

    public SlaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Sla>> GetSlasAsync(CancellationToken cancellationToken)
    {
        return await _context.Slas.ToListAsync(cancellationToken);
    }

    public async Task<Sla> GetSlasByRequestTypeAsync(RequestType requestType, CancellationToken cancellationToken)
    {
        return (await _context.Slas.FirstOrDefaultAsync(x => x.RequestType == requestType,
            cancellationToken: cancellationToken))!;
    }

    public async Task<Sla> GetSlaByIdAsync(Guid slaId,CancellationToken cancellationToken)
    {
        return (await _context.Slas.FirstOrDefaultAsync(x => x.Id == slaId,
            cancellationToken: cancellationToken))!;
    }

    public async Task<Sla> CreateSlaAsync(Sla sla, CancellationToken cancellationToken)
    {
        return (await _context.Slas.AddAsync(sla, cancellationToken)).Entity;
    }
}