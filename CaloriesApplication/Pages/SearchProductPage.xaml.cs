using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CaloriesApplication.Data;

namespace CaloriesApplication
{
    public partial class SearchProductPage : Page
    {
        public SearchProductPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string productName = ProductNameTextBox.Text;
            string kiloCalories = KiloCaloriesTextBox.Text;

            using (var context = new FoodDbContext())
            {
                var query = context.Products.AsQueryable();

                if (!string.IsNullOrWhiteSpace(productName))
                {
                    query = query.Where(p => p.Name.Contains(productName));
                }

                if (!string.IsNullOrWhiteSpace(kiloCalories))
                {
                    if (decimal.TryParse(kiloCalories, out decimal calories))
                    {
                        query = query.Where(p => p.KiloCaloriesPer100Grams == calories);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for kilo calories", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                List<Product> searchResults = query.ToList();
                SearchResultsListView.ItemsSource = searchResults;
            }
        }

        private void ProductNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void KiloCaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
