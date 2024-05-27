using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using CaloriesApplication.Data;

namespace CaloriesApplication
{
    public partial class SearchDishPage : Page
    {
        public SearchDishPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string dishName = DishNameTextBox.Text;
            string kiloCalories = KiloCaloriesTextBox.Text;

            using (var context = new FoodDbContext())
            {
                var query = context.Dishes.AsQueryable();

                if (!string.IsNullOrWhiteSpace(dishName))
                {
                    query = query.Where(d => d.Name.Contains(dishName));
                }

                if (!string.IsNullOrWhiteSpace(kiloCalories))
                {
                    if (decimal.TryParse(kiloCalories, out decimal calories))
                    {
                        query = query.Where(d => d.KiloCaloriesPer100Grams == calories);
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid number for kilo calories", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    } 
                }

                List<Dish> searchResults = query.ToList();
                SearchResultsListView.ItemsSource = searchResults;
            }
        }

        private void DishNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void KiloCaloriesTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
