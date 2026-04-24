namespace CannabisMath.Core.Weights;

public static class WeightConverter
{
    public const decimal GramsPerRetailEighth = 3.5m;
    public const decimal GramsPerRetailQuarter = 7m;
    public const decimal GramsPerRetailHalfOunce = 14m;
    public const decimal GramsPerRetailOunce = 28m;

    public const decimal GramsPerExactOunce = 28.349523125m;
    public const decimal GramsPerExactPound = 453.59237m;

    public static decimal GramsToRetailEighths(decimal grams)
    {
        ValidateNonNegative(grams, nameof(grams));
        return grams / GramsPerRetailEighth;
    }

    public static decimal RetailEighthsToGrams(decimal eighths)
    {
        ValidateNonNegative(eighths, nameof(eighths));
        return eighths * GramsPerRetailEighth;
    }

    public static decimal GramsToRetailOunces(decimal grams)
    {
        ValidateNonNegative(grams, nameof(grams));
        return grams / GramsPerRetailOunce;
    }

    public static decimal RetailOuncesToGrams(decimal ounces)
    {
        ValidateNonNegative(ounces, nameof(ounces));
        return ounces * GramsPerRetailOunce;
    }

    public static decimal GramsToExactOunces(decimal grams)
    {
        ValidateNonNegative(grams, nameof(grams));
        return grams / GramsPerExactOunce;
    }

    public static decimal ExactOuncesToGrams(decimal ounces)
    {
        ValidateNonNegative(ounces, nameof(ounces));
        return ounces * GramsPerExactOunce;
    }

    public static decimal GramsToExactPounds(decimal grams)
    {
        ValidateNonNegative(grams, nameof(grams));
        return grams / GramsPerExactPound;
    }

    public static decimal ExactPoundsToGrams(decimal pounds)
    {
        ValidateNonNegative(pounds, nameof(pounds));
        return pounds * GramsPerExactPound;
    }

    private static void ValidateNonNegative(decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value cannot be negative.");
        }
    }
}