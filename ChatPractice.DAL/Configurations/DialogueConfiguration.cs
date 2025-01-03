using BelvedereFood.DAL.Models;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelvedereFood.DAL.Configurations;

public class DialogueConfiguration : BaseConfiguration<Dialogue>
{
    public override void Configure(EntityTypeBuilder<Dialogue> builder)
    {
        base.Configure(builder);

        builder.ToTable("dialogue");
    }
}