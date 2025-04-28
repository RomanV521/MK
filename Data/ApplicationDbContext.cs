using MK.Models;
using Microsoft.EntityFrameworkCore;
namespace MK.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Quote>()
            .HasOne(q => q.Author)
            .WithMany(a => a.Quotes)
            .HasForeignKey(q => q.AuthorId);

        modelBuilder.Entity<Quote>()
            .HasMany(q => q.Tags)
            .WithMany(t => t.Quotes)
            .UsingEntity(j => j.ToTable("QuoteTags")); // таблиця-зв'язка
    }
}