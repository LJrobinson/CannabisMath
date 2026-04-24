namespace CannabisMath.Core.Dosing;

public static class DoseCalculator
{
    public static decimal MgPerServing(decimal totalMg, decimal servings)
    {
        ValidateNonNegative(totalMg, nameof(totalMg));
        ValidatePositive(servings, nameof(servings));

        return totalMg / servings;
    }

    public static decimal TotalMgFromPercent(decimal weightGrams, decimal potencyPercent)
    {
        ValidateNonNegative(weightGrams, nameof(weightGrams));
        ValidateNonNegative(potencyPercent, nameof(potencyPercent));

        return weightGrams * 1000m * (potencyPercent / 100m);
    }

    public static decimal MgPerGram(decimal potencyPercent)
    {
        ValidateNonNegative(potencyPercent, nameof(potencyPercent));

        return 1000m * (potencyPercent / 100m);
    }

    public static decimal DabMg(decimal potencyPercent, decimal dabSizeGrams)
    {
        ValidateNonNegative(potencyPercent, nameof(potencyPercent));
        ValidateNonNegative(dabSizeGrams, nameof(dabSizeGrams));

        return TotalMgFromPercent(dabSizeGrams, potencyPercent);
    }

    private static void ValidateNonNegative(decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value cannot be negative.");
        }
    }

    private static void ValidatePositive(decimal value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value must be greater than zero.");
        }
    }
}