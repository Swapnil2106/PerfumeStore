using Microsoft.EntityFrameworkCore;
using PerfumeStore.Models;

namespace PerfumeStore.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Perfumes)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.Type)
                .WithMany(p => p.Perfumes)
                .HasForeignKey(p => p.TypeId);
        }
    }
}
