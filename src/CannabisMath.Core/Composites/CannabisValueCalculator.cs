using CannabisMath.Core.Dosing;
using CannabisMath.Core.Pricing;

namespace CannabisMath.Core.Composites;

public static class CannabisValueCalculator
{
    public static decimal TotalMgFromWeightAndPotency(decimal weightGrams, decimal potencyPercent)
    {
        return DoseCalculator.TotalMgFromPercent(weightGrams, potencyPercent);
    }

    public static decimal PricePerMgFromWeightAndPotency(
        decimal price,
        decimal weightGrams,
        decimal potencyPercent)
    {
        var totalMg = DoseCalculator.TotalMgFromPercent(weightGrams, potencyPercent);

        return PriceCalculator.PricePerMg(price, totalMg);
    }

    public static decimal PricePerGramAfterDiscount(
        decimal price,
        decimal grams,
        decimal percentOff)
    {
        var discountedPrice = PriceCalculator.DiscountedPrice(price, percentOff);

        return PriceCalculator.PricePerGram(discountedPrice, grams);
    }

    public static decimal PricePerMgAfterDiscount(
        decimal price,
        decimal weightGrams,
        decimal potencyPercent,
        decimal percentOff)
    {
        var discountedPrice = PriceCalculator.DiscountedPrice(price, percentOff);
        var totalMg = DoseCalculator.TotalMgFromPercent(weightGrams, potencyPercent);

        return PriceCalculator.PricePerMg(discountedPrice, totalMg);
    }
}