using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SlaSystem.Infrastructure.Persistence.Config;

public class SlaConfiguration : IEntityTypeConfiguration<Sla>
{
    public void Configure(EntityTypeBuilder<Sla> builder)
    {
        builder.Property(s => s.Id).IsRequired();
        builder.Property(s => s.RequestType).IsRequired().HasConversion<string>().IsUnicode(false);
        builder.Property(s => s.Severity).IsRequired();
        builder.Property(s => s.DurationInHours).IsRequired();
    }
}