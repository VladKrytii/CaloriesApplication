using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesApplication.CalculationLogic
{
    class calorieCalculator
    {
        double malebmr, femalebmr, calories;
        int bmrmult;
        string gender, exercise;
        double height, weight, age;
        private void calorieCalculator_Load(object sender, EventArgs e)
        {
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            height = double.Parse(heightTextBox.Text);
            weight = double.Parse(weightTextBox.Text);
            age = double.Parse(ageTextBox.Text);
            if (genderList.SelectedIndex != -1)
            {
                gender = genderList.SelectedItem.ToString();
                switch (gender)
                {
                    case "Male":
                        //perform calculation
                        malebmr = (9.99 * weight + 6,25 * height - 4,92 * age + 5);
                        calories = malebmr * bmrmult;
                        /*bmrDisplay.Text = ("Your base metabolic rate burns " + calories + " calories");*/
                        break;
                    case "Female":
                        femalebmr = 9.99 * weight + 6,25 * height - 4,92 * age + 5 - 161;
                        MessageBox.Show("You should eat:" + femalebmr + "calories");
                        break;
                }

            }
            if (exerciseList.SelectedIndex != -1)
            {
                string exercise;
                exercise = exerciseList.SelectedItem.ToString();
                switch (exercise)
                {
                    case "Light exercise (1–3 days per week)":
                        bmrmult = (int)1.375m;
                        break;
                    case "Moderate exercise (3–5 days per week)":
                        bmrmult = (int)1.55m;
                        break;
                    case "Heavy exercise (6–7 days per week)":
                        bmrmult = (int)1.725m;
                        break;
                    case "Very heavy exercise (twice per day, extra heavy workouts)":
                        bmrmult = (int)1.9m;
                        break;
                }
            }
        }
    }
}
