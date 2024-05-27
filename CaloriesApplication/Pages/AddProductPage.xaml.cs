using System.Windows;
using System.Windows.Controls;
using CaloriesApplication.Database;

namespace CaloriesApplication
{
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string caloriesPer100Grams = CaloriesTextBox.Text;
            string description = DescriptionTextBox.Text;

            EnteredDataTextBox.Text = $"Product Name :: {name}\nCaloriesPer100Grams :: {caloriesPer100Grams}\nDescription :: {description}";


            using (var context = new FoodDbContext())
            {
                var product = new Product
                {
                    Name = name,
                    KiloCaloriesPer100Grams = decimal.Parse(caloriesPer100Grams),
                    Description = description
                };

                context.Products.Add(product);
                context.SaveChanges();
            }

            MessageBox.Show("Added!", "Confirm", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
