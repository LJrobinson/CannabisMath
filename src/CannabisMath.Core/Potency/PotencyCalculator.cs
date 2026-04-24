namespace CannabisMath.Core.Potency;

public static class PotencyCalculator
{
    private const decimal AcidToNeutralConversionFactor = 0.877m;

    public static decimal CalculateTotalThc(decimal thcPercent, decimal thcaPercent)
    {
        ValidateNonNegative(thcPercent, nameof(thcPercent));
        ValidateNonNegative(thcaPercent, nameof(thcaPercent));

        return thcPercent + (thcaPercent * AcidToNeutralConversionFactor);
    }

    public static decimal CalculateTotalCbd(decimal cbdPercent, decimal cbdaPercent)
    {
        ValidateNonNegative(cbdPercent, nameof(cbdPercent));
        ValidateNonNegative(cbdaPercent, nameof(cbdaPercent));

        return cbdPercent + (cbdaPercent * AcidToNeutralConversionFactor);
    }

    private static void ValidateNonNegative(decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value cannot be negative.");
        }
    }
}