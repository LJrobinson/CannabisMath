using CannabisMath.Core.Pricing;

namespace CannabisMath.Core.Tests.Pricing;

public class PriceCalculatorTests
{
    [Fact]
    public void PricePerGram_ValidInput_ReturnsCorrectValue()
    {
        var result = PriceCalculator.PricePerGram(35m, 3.5m);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void PricePerMg_ValidInput_ReturnsCorrectValue()
    {
        var result = PriceCalculator.PricePerMg(25m, 500m);

        Assert.Equal(0.05m, result);
    }

    [Fact]
    public void DiscountedPrice_TwentyPercentOff_ReturnsDiscountedPrice()
    {
        var result = PriceCalculator.DiscountedPrice(100m, 20m);

        Assert.Equal(80m, result);
    }

    [Fact]
    public void SavingsAmount_TwentyPercentOff_ReturnsSavingsAmount()
    {
        var result = PriceCalculator.SavingsAmount(100m, 20m);

        Assert.Equal(20m, result);
    }

    [Fact]
    public void DiscountedPrice_OneHundredPercentOff_ReturnsZero()
    {
        var result = PriceCalculator.DiscountedPrice(100m, 100m);

        Assert.Equal(0m, result);
    }

    [Fact]
    public void PricePerGram_ZeroGrams_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PriceCalculator.PricePerGram(35m, 0m));
    }

    [Fact]
    public void PricePerMg_ZeroMg_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PriceCalculator.PricePerMg(25m, 0m));
    }

    [Fact]
    public void DiscountedPrice_OverOneHundredPercent_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PriceCalculator.DiscountedPrice(100m, 101m));
    }
}