using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SlaSystem.Infrastructure.Persistence.Config;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id).IsRequired();
        builder.Property(u => u.UserName).IsRequired().IsUnicode(false);
        builder.Property(u => u.Password).IsRequired().IsUnicode(false);
        builder.Property(u => u.Role).IsRequired().HasConversion<string>();
        builder.Property(u => u.Zone).IsRequired().IsUnicode(false);

        builder.HasOne(u => u.Queue)
            .WithMany(q => q.Users)
            .HasForeignKey(u => u.QueueId)
            .OnDelete(DeleteBehavior.NoAction);
        
        // builder.HasMany(u => u.MyCreatedRequests)
        //     .WithOne(r => r.Client)
        //     .HasForeignKey(r => r.ClientId)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder.HasMany(u => u.OwnedRequests)
        //     .WithOne(r => r.Owner)
        //     .HasForeignKey(r => r.OwnerId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}