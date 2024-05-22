// ﻿using System.Windows;
// <<<<<<< dish_food_calorie
// using CaloriesApplication.Data;
// using System.Linq;
// =======
// >>>>>>> get_calories_product

namespace CaloriesApplication
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
                        new Product { Name = "Product 1", KiloCaloriesPer100Grams = 264M, Description = "Description 1" }
                    );

                    context.Dishes.AddRange(
                        new Dish { Name = "Dish 1", KiloCaloriesPer100Grams = 149M, Description = "Description A" }
                    );

                    context.SaveChanges();
                }
            }
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Content = new AddProductPage();
        }

        private void SearchProduct_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Content = new SearchProductPage();
        }

        private void AddDish_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Content = new AddDishPage();
        }

        private void SearchDish_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Content = new SearchDishPage();
        }

        private void NeededCalories_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Content = new NeededCaloriesPage();
        }
    }
}
