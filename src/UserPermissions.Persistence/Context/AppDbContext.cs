using Microsoft.EntityFrameworkCore;
using UserPermissions.Domain.Entities;

namespace UserPermissions.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<PermissionType> PermissionTypes => Set<PermissionType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>()
            .HasOne(p => p.PermissionType)
            .WithMany()
            .HasForeignKey(p => p.PermissionTypeId);
    }
}
