using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SlaSystem.Infrastructure.Persistence.Config;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.Property(r => r.Id).IsRequired();
        builder.Property(r => r.RequestType).IsRequired().HasConversion<string>().IsUnicode(false);
        builder.Property(r => r.Description).IsRequired().IsUnicode(false);
        builder.Property(r => r.ClientId).IsRequired();
        builder.Property(r => r.SlaId).IsRequired();
        builder.Property(r => r.CreatedAt).IsRequired();
        builder.Property(r => r.RequestStatus).HasConversion<string>().IsUnicode(false);
        builder.Property(r => r.SlaStatus) .HasConversion<string>().IsUnicode(false);
        builder.Property(r => r.ClosedAt);

        builder.HasOne(r => r.Sla)
            .WithOne()
            .HasForeignKey<Request>(r => r.SlaId);

        builder.HasOne(r => r.Owner)
            .WithMany(u => u.OwnedRequests)
            .HasForeignKey(r => r.OwnerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(r => r.Client)
            .WithMany(u => u.MyCreatedRequests)
            .HasForeignKey(r => r.ClientId)
            .OnDelete(DeleteBehavior.Restrict);
        
        
        builder.Property(r => r.SlaExpiredOn)
            .IsRequired()
            .HasComputedColumnSql("DATEADD(HOUR, [Sla].[DurationInHours], [CreatedAt])");
    }
}