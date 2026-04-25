using CannabisMath.Core.Composites;

namespace CannabisMath.Core.Tests.Composites;

public class CannabisValueCalculatorTests
{
    [Fact]
    public void TotalMgFromWeightAndPotency_ReturnsCorrectValue()
    {
        var result = CannabisValueCalculator.TotalMgFromWeightAndPotency(3.5m, 20m);

        Assert.Equal(700m, result);
    }

    [Fact]
    public void PricePerMgFromWeightAndPotency_ReturnsCorrectValue()
    {
        var result = CannabisValueCalculator.PricePerMgFromWeightAndPotency(
            price: 35m,
            weightGrams: 3.5m,
            potencyPercent: 20m);

        Assert.Equal(0.05m, result);
    }

    [Fact]
    public void PricePerGramAfterDiscount_ReturnsCorrectValue()
    {
        var result = CannabisValueCalculator.PricePerGramAfterDiscount(
            price: 40m,
            grams: 3.5m,
            percentOff: 12.5m);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void PricePerMgAfterDiscount_ReturnsCorrectValue()
    {
        var result = CannabisValueCalculator.PricePerMgAfterDiscount(
            price: 40m,
            weightGrams: 3.5m,
            potencyPercent: 20m,
            percentOff: 12.5m);

        Assert.Equal(0.05m, result);
    }

    [Fact]
    public void PricePerMgFromWeightAndPotency_ZeroPotency_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            CannabisValueCalculator.PricePerMgFromWeightAndPotency(
                price: 35m,
                weightGrams: 3.5m,
                potencyPercent: 0m));
    }
}