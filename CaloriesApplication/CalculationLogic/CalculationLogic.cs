public class CalculationLogic
{
    public double CalculateCalories(double height, double weight, double age, string gender, string exercise)
    {
        double bmr = 0;
        double bmrmult = 1;

        // Perform gender-specific BMR calculation
        if (gender == "Male")
        {
            bmr = (weight * 10 + height * 6.25 - age * 5 - 5);
        }
        else if (gender == "Female")
        {
            bmr = (weight * 10 + height * 6.25 - age * 5 - 161);
        }

        // Determine exercise multiplier
        switch (exercise)
        {
            case "Light exercise (1–3 days per week)":
                bmrmult = 1.375;
                break;
            case "Moderate exercise (3–5 days per week)":
                bmrmult = 1.55;
                break;
            case "Heavy exercise (6–7 days per week)":
                bmrmult = 1.725;
                break;
            case "Very heavy exercise (twice per day, extra heavy workouts)":
                bmrmult = 1.9;
                break;
        }

        // Calculate total calories
        double calories = bmr * bmrmult;
        return calories;
    }
}
