using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;

namespace TeamProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using (var context = new FoodDbContext())
            {
                context.Database.EnsureCreated();

                if (context.Products != null && !context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Product 1", KiloCaloriesPer100Grams = 264M, Description = "Description 1" },
                        new Product { Name = "Product 2", KiloCaloriesPer100Grams = 319M, Description = "Description 2" },
                        new Product { Name = "Product 3", KiloCaloriesPer100Grams = 67.5M, Description = "Description 3" }
                    );

                    context?.Dishes?.AddRange(
                        new Dish { Name = "Dish 1", KiloCaloriesPer100Grams = 149M, Description = "Description A" },
                        new Dish { Name = "Dish 2", KiloCaloriesPer100Grams = 270M, Description = "Description B" },
                        new Dish { Name = "Dish 3", KiloCaloriesPer100Grams = 152M, Description = "Description C" }
                    );

                    context?.SaveChanges();
                }
            }
        }

        public class FoodDbContext : DbContext
        {
            public DbSet<Product>? Products { get; set; }
            public DbSet<Dish>? Dishes { get; set; }

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

        public class Product
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal KiloCaloriesPer100Grams { get; set; }
            public string? Description { get; set; }
        }

        public class Dish
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public decimal KiloCaloriesPer100Grams { get; set; }
            public string? Description { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Welcome everyone!");
        }

        private void CheckDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new FoodDbContext())
            {
                var products = context.Products?.ToList();
                var dishes = context.Dishes?.ToList();

                string productInfo = "Products:\n";
                foreach (var product in products)
                {
                    productInfo += $"ID: {product.Id}, Name: {product.Name}, Kcal: {product.KiloCaloriesPer100Grams}, Description: {product.Description}\n";
                }

                string dishInfo = "Dishes:\n";
                foreach (var dish in dishes)
                {
                    dishInfo += $"ID: {dish.Id}, Name: {dish.Name}, Kcal: {dish.KiloCaloriesPer100Grams}, Description: {dish.Description}\n";
                }

                MessageBox.Show(productInfo + "\n" + dishInfo);
            }
        }
    }
}
