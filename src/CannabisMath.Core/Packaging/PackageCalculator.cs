namespace CannabisMath.Core.Packaging;

public static class PackageCalculator
{
    public static int FullUnits(decimal totalGrams, decimal gramsPerUnit)
    {
        ValidateNonNegative(totalGrams, nameof(totalGrams));
        ValidatePositive(gramsPerUnit, nameof(gramsPerUnit));

        return (int)(totalGrams / gramsPerUnit);
    }

    public static decimal RemainingGrams(decimal totalGrams, decimal gramsPerUnit)
    {
        ValidateNonNegative(totalGrams, nameof(totalGrams));
        ValidatePositive(gramsPerUnit, nameof(gramsPerUnit));

        var fullUnits = FullUnits(totalGrams, gramsPerUnit);
        return totalGrams - (fullUnits * gramsPerUnit);
    }

    public static (int fullUnits, decimal remainingGrams) Breakdown(decimal totalGrams, decimal gramsPerUnit)
    {
        var units = FullUnits(totalGrams, gramsPerUnit);
        var remainder = RemainingGrams(totalGrams, gramsPerUnit);

        return (units, remainder);
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

    public static PackageBreakdownResult CalculateBreakdownResult(decimal totalGrams, decimal gramsPerUnit)
    {
        var fullUnits = FullUnits(totalGrams, gramsPerUnit);
        var remainingGrams = RemainingGrams(totalGrams, gramsPerUnit);

        return new PackageBreakdownResult(
            TotalGrams: totalGrams,
            GramsPerUnit: gramsPerUnit,
            FullUnits: fullUnits,
            RemainingGrams: remainingGrams
        );
    }
}