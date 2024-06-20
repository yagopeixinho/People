using Microsoft.EntityFrameworkCore;
using People.People.Core.Entities;

namespace People.People.Infrastructure.Data.Context;

public class PeopleContext : DbContext
{
    public PeopleContext(DbContextOptions<PeopleContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(256); 
        });

        base.OnModelCreating(modelBuilder);
    }
}