using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SlaSystem.Infrastructure.Persistence.Config;

public class QueueConfiguration : IEntityTypeConfiguration<Queue>
{
    public void Configure(EntityTypeBuilder<Queue> builder)
    {
        builder.Property(q => q.Id).IsRequired();
        builder.Property(q => q.QueueName).IsUnicode(false);
        builder.Property(q => q.RequestType).IsRequired().HasConversion<string>().IsUnicode(false);
        builder.HasMany(q => q.Users)
            .WithOne(u => u.Queue)
            .HasForeignKey(u => u.QueueId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}