using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatPractice.DAL.Configurations;

public class ChatMessageConfiguration : BaseConfiguration<ChatMessage>
{
    public override void Configure(EntityTypeBuilder<ChatMessage> builder)
    {
        base.Configure(builder);

        builder.ToTable("message");

        builder.Property(x => x.SenderId)
            .IsRequired();

        builder.Property(x => x.Text)
            .HasMaxLength(8 * 4096)
            .IsRequired();

        builder.Property(x => x.SendingDate)
            .IsRequired();
    }
}