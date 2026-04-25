namespace CannabisMath.Core.Taxes;

public static class TaxCalculator
{
    public static decimal TaxAmount(decimal subtotal, decimal taxRatePercent)
    {
        ValidateNonNegative(subtotal, nameof(subtotal));
        ValidatePercent(taxRatePercent, nameof(taxRatePercent));

        return subtotal * (taxRatePercent / 100m);
    }

    public static decimal TotalWithTax(decimal subtotal, decimal taxRatePercent)
    {
        return subtotal + TaxAmount(subtotal, taxRatePercent);
    }

    public static decimal CombinedTaxRate(params decimal[] taxRatePercents)
    {
        if (taxRatePercents is null)
        {
            throw new ArgumentNullException(nameof(taxRatePercents));
        }

        decimal total = 0m;

        foreach (var rate in taxRatePercents)
        {
            ValidatePercent(rate, nameof(taxRatePercents));
            total += rate;
        }

        return total;
    }

    public static decimal TotalWithCombinedTaxes(decimal subtotal, params decimal[] taxRatePercents)
    {
        var combinedRate = CombinedTaxRate(taxRatePercents);

        return TotalWithTax(subtotal, combinedRate);
    }

    public static decimal TaxAmountFromRate(decimal subtotal, decimal taxRate)
    {
        ValidateNonNegative(subtotal, nameof(subtotal));
        ValidateRate(taxRate, nameof(taxRate));

        return subtotal * taxRate;
    }

    public static decimal TotalWithTaxRate(decimal subtotal, decimal taxRate)
    {
        return subtotal + TaxAmountFromRate(subtotal, taxRate);
    }

    private static void ValidateNonNegative(decimal value, string parameterName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Value cannot be negative.");
        }
    }

    private static void ValidatePercent(decimal value, string parameterName)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Percent must be between 0 and 100.");
        }
    }

    private static void ValidateRate(decimal value, string parameterName)
    {
        if (value < 0 || value > 1)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Rate must be between 0 and 1.");
        }
    }
}