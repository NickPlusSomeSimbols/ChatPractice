﻿using BelvedereFood.DAL.Models;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace ChatPractice.DAL;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<Dialogue> Dialogues { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
        {
            property.SetColumnType("decimal(18,2)");
        }

        modelBuilder.Entity<Dialogue>()
            .HasOne(d => d.UserOne)
            .WithMany()
            .HasForeignKey(d => d.UserOneId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.Entity<Dialogue>()
            .HasOne(d => d.UserTwo)
            .WithMany() 
            .HasForeignKey(d => d.UserTwoId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        modelBuilder.ApplyGlobalFilters<BaseModel>(e => e.IsDeleted == false);
    }
}
public static class ModelBuilderExtension
{
    public static void ApplyGlobalFilters<T>(this ModelBuilder modelBuilder, Expression<Func<T, bool>> expression)
    {
        var entities = modelBuilder.Model
            .GetEntityTypes()
            .Where(x => x.ClrType.BaseType == typeof(T))
            .Select(e => e.ClrType);
        foreach (var entity in entities)
        {
            var newParam = Expression.Parameter(entity);
            var newbody = ReplacingExpressionVisitor.Replace(expression.Parameters.Single(), newParam, expression.Body);
            modelBuilder.Entity(entity).HasQueryFilter(Expression.Lambda(newbody, newParam));
        }
    }
}