using Microsoft.EntityFrameworkCore;

namespace CaloriesApplication.Database
{
    public class FoodDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Dish>? Dishes { get; set; }
        public object Product { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseSqlite("Data Source=Food.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsUnicode(true);
            modelBuilder.Entity<Product>().Property(p => p.Description).IsUnicode(true);

            modelBuilder.Entity<Dish>().Property(d => d.Name).IsUnicode(true);
            modelBuilder.Entity<Dish>().Property(d => d.Description).IsUnicode(true);
        }
    }
}
