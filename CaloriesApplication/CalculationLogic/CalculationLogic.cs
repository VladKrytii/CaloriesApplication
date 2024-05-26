public class CalculationLogic
{
    public double CalculateCalories(double height, double weight, double age, string gender, string exercise)
    {
        double bmr = 0;
        double calories = 0;
        int bmrmult = 1;

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

        // Calculate total calories
        calories = bmr * bmrmult;
        return calories;
    }
}
