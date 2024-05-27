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
                string trueGender = "";
                if (gender.Contains("Male"))
                {
                    trueGender = "Male";
                }
                else if (gender.Contains("Female"))
                {
                    trueGender = "Female";
                }
                string exercise = loadCombo.SelectedItem.ToString();
                string trueExercise = "";
                if (exercise.Contains("Light exercise (1–3 days per week)"))
                {
                    trueExercise = "Light exercise (1–3 days per week)";
                }
                else if (exercise.Contains("Moderate exercise (3–5 days per week)"))
                {
                    trueExercise = "Moderate exercise (3–5 days per week)";
                }
                else if (exercise.Contains("Heavy exercise (6–7 days per week)"))
                {
                    trueExercise = "Heavy exercise (6–7 days per week)";
                }
                else if (exercise.Contains("Very heavy exercise (twice per day, extra heavy workouts)"))
                {
                    trueExercise = "Very heavy exercise (twice per day, extra heavy workouts)";
                }
                // Calculate calories
                CalculationLogic calcLogic = new CalculationLogic();
                double calories = calcLogic.CalculateCalories(height, weight, age, trueGender, trueExercise);

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
