using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace CaloriesApplication
{
    /// <summary>
    /// Interaction logic for NeededCaloriesPage.xaml
    /// </summary>
    public partial class NeededCaloriesPage : Page
    {
        private CalculationLogic calculationLogic;

        public NeededCaloriesPage()
        {
            InitializeComponent();
            calculationLogic = new CalculationLogic();

        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values
                double height = double.Parse(heightTextBox.Text);
                double weight = double.Parse(weightTextBox.Text);
                double age = double.Parse(ageTextBox.Text);
                string gender = genderCombo.SelectedItem.ToString();
                string exercise = loadCombo.SelectedItem.ToString();

                // Calculate calories
                CalculationLogic calcLogic = new CalculationLogic();
                double calories = calcLogic.CalculateCalories(height, weight, age, gender, exercise);

                // Display result
                bmrDisplay.Text = $"Your base metabolic rate burns {calories} calories";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
