namespace CannabisMath.Core.Rounding;

public static class RoundingCalculator
{
    public static decimal RoundCurrency(decimal value)
    {
        return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    public static decimal RoundWeight(decimal value)
    {
        return decimal.Round(value, 3, MidpointRounding.AwayFromZero);
    }

    public static decimal RoundMilligrams(decimal value)
    {
        return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    public static decimal RoundPercent(decimal value)
    {
        return decimal.Round(value, 2, MidpointRounding.AwayFromZero);
    }

    public static decimal RoundToIncrement(decimal value, decimal increment, RoundingMode mode)
    {
        ValidatePositive(increment, nameof(increment));

        var quotient = value / increment;

        var roundedQuotient = mode switch
        {
            RoundingMode.Nearest => decimal.Round(quotient, 0, MidpointRounding.AwayFromZero),
            RoundingMode.Up => decimal.Ceiling(quotient),
            RoundingMode.Down => decimal.Floor(quotient),
            RoundingMode.AwayFromZero => quotient >= 0
                ? decimal.Ceiling(quotient)
                : decimal.Floor(quotient),
            RoundingMode.ToZero => quotient >= 0
                ? decimal.Floor(quotient)
                : decimal.Ceiling(quotient),
            _ => throw new ArgumentOutOfRangeException(nameof(mode), mode, "Unsupported rounding mode.")
        };

        return roundedQuotient * increment;
    }

    public static decimal RoundCashToNearestNickel(decimal value)
    {
        return RoundToIncrement(value, 0.05m, RoundingMode.Nearest);
    }

    public static decimal RoundCashUpToNickel(decimal value)
    {
        return RoundToIncrement(value, 0.05m, RoundingMode.Up);
    }

    public static decimal RoundCashDownToNickel(decimal value)
    {
        return RoundToIncrement(value, 0.05m, RoundingMode.Down);
    }

    public static decimal RoundingDifference(decimal originalValue, decimal roundedValue)
    {
        return roundedValue - originalValue;
    }

    private static void ValidatePositive(decimal value, string parameterName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value must be greater than zero.");
        }
    }
}