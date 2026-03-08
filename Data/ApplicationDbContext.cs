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
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

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

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CartItem>()
               .HasOne(ci => ci.Cart)
               .WithMany(c => c.CartItems)
               .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Perfume)
                .WithMany()
                .HasForeignKey(ci => ci.PerfumeId);
        }
    }
}
