using Microsoft.EntityFrameworkCore;

namespace BookApp_temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Category>().HasData(
                new Model.Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Model.Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Model.Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );
        }
    }
}
