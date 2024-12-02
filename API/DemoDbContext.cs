using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API;

public class DemoDbContext : DbContext
{
    public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options) { }

    public DbSet<ArticleEntity> Articles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<ArticleEntity>()
            .HasData(
                new ArticleEntity()
                {
                    Id = 1,
                    Title = "Hello World",
                    Content = "This is the first article",
                    AuthorName = "Andrey",
                }
            );
    }
}
