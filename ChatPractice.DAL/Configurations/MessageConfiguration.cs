using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelvedereFood.DAL.Configurations;

public class MessageConfiguration : BaseConfiguration<Message>
{
    public override void Configure(EntityTypeBuilder<Message> builder)
    {
        base.Configure(builder);

        builder.ToTable("message");

        builder.Property(x => x.PostDate)
            .IsRequired();

        builder.Property(x => x.UserId)
            .IsRequired();

        builder.Property(x => x.Text)
            .HasMaxLength(8 * 4096)
            .IsRequired();
    }
}