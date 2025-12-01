using Microsoft.EntityFrameworkCore;
using MinimalApiTemplate.Features.Users;

namespace MinimalApiTemplate.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User>   Users   => Set<User>();

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>(e =>
        {
            e.ToTable("users");
            e.HasKey(u => u.Id);
            e.Property(u => u.Id)       .HasColumnName("id").UseIdentityByDefaultColumn();
            e.Property(u => u.Email)    .HasColumnName("email").IsRequired().HasMaxLength(100);
            e.HasIndex(u => u.Email).IsUnique();
            e.Property(u => u.Password) .HasColumnName("password_hash").IsRequired();
            e.Property(u => u.Role)     .HasColumnName("role").IsRequired().HasMaxLength(20);
        });
    }
}