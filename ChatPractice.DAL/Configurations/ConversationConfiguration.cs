using BelvedereFood.DAL.Models;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelvedereFood.DAL.Configurations;

public class ConversationConfiguration : BaseConfiguration<Conversation>
{
    public override void Configure(EntityTypeBuilder<Conversation> builder)
    {
        base.Configure(builder);

        builder.ToTable("conversation");
    }
}