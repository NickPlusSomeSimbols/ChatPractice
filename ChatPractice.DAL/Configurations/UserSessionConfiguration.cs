using BelvedereFood.DAL.Models;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelvedereFood.DAL.Configurations;

public class UserSessionConfiguration : BaseConfiguration<UserSession>
{
    public override void Configure(EntityTypeBuilder<UserSession> builder)
    {
        base.Configure(builder);

        builder.ToTable("user_session");

        builder.Property(x => x.Token)
            .IsRequired();

        builder.Property(x => x.IsExpired)
            .IsRequired();
    }
}