using System.Windows;
using System.Windows.Controls;
using CaloriesApplication.Database;

namespace CaloriesApplication
{
    public partial class AddDishPage : Page
    {
        public AddDishPage()
        {
            InitializeComponent();
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string kiloCalories = KiloCaloriesTextBox.Text;
            string description = DescriptionTextBox.Text;

            EnteredDataTextBox.Text = $"Dish Name :: {name}\nKiloCaloriesPer100Grams :: {kiloCalories}\nDescription :: {description}";

            using (var context = new FoodDbContext())
            {
                var dish = new Dish
                {
                    Name = name,
                    KiloCaloriesPer100Grams = decimal.Parse(kiloCalories),
                    Description = description
                };

                context.Dishes.Add(dish);
                context.SaveChanges();
            }

            MessageBox.Show("Added!", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
