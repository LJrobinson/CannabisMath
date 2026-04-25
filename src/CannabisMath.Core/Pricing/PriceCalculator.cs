namespace CannabisMath.Core.Pricing;

public static class PriceCalculator
{
    public static decimal PricePerGram(decimal price, decimal grams)
    {
        ValidateNonNegative(price, nameof(price));
        ValidatePositive(grams, nameof(grams));

        return price / grams;
    }

    public static decimal PricePerMg(decimal price, decimal totalMg)
    {
        ValidateNonNegative(price, nameof(price));
        ValidatePositive(totalMg, nameof(totalMg));

        return price / totalMg;
    }

    public static decimal DiscountedPrice(decimal price, decimal percentOff)
    {
        ValidateNonNegative(price, nameof(price));
        ValidatePercent(percentOff, nameof(percentOff));

        return price * (1m - (percentOff / 100m));
    }

    public static decimal SavingsAmount(decimal price, decimal percentOff)
    {
        ValidateNonNegative(price, nameof(price));
        ValidatePercent(percentOff, nameof(percentOff));

        return price * (percentOff / 100m);
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

    private static void ValidatePercent(decimal value, string parameterName)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentOutOfRangeException(parameterName, "Percent must be between 0 and 100.");
        }
    }

    public static PricingResult CalculatePricePerGramResult(decimal price, decimal grams)
    {
        var unitPrice = PricePerGram(price, grams);

        return new PricingResult(
            Price: price,
            Quantity: grams,
            UnitPrice: unitPrice,
            UnitLabel: "gram"
        );
    }

    public static PricingResult CalculatePricePerMgResult(decimal price, decimal totalMg)
    {
        var unitPrice = PricePerMg(price, totalMg);

        return new PricingResult(
            Price: price,
            Quantity: totalMg,
            UnitPrice: unitPrice,
            UnitLabel: "mg"
        );
    }
}