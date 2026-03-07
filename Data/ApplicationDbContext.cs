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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.PerfumeCategory)
                .WithMany(p => p.Perfumes)
                .HasForeignKey(p => p.PerfumeCategoryId);

            modelBuilder.Entity<Perfume>()
                .HasOne(p => p.PerfumeType)
                .WithMany(p => p.Perfumes)
                .HasForeignKey(p => p.PerfumeTypeId);
        }
    }
}
