using BelvedereFood.DAL.Models;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatPractice.DAL;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<Conversation> Conversations { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}
