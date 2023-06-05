using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SlaSystem.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
    
    public DbSet<Queue> Queues { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Request> Requests { get; set; } = null!;
    public DbSet<Sla> Slas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        if (Database.ProviderName != "Microsoft.EntityFrameworkCore.Sqlite") return;
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties().
                Where(p => p.PropertyType == typeof(decimal));
        
            foreach (var property in properties)
            {
                modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
            }
        }
    }
}