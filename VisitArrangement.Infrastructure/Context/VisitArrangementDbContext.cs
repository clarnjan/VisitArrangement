namespace VisitArrangement.Infrastructure.Context;

using Microsoft.EntityFrameworkCore;
using VisitArrangement.Domain.Entities;

public class VisitArrangementDbContext : DbContext
{
    public VisitArrangementDbContext(DbContextOptions<VisitArrangementDbContext> options) : base(options) { }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users"); // Rename table from AspNetUsers to Users
        });

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
            property.SetColumnType("varchar(450)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VisitArrangementDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
