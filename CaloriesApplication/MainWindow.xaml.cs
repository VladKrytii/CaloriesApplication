using System.Windows;

namespace CaloriesApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    // test branch
}