using CannabisMath.Core.Rounding;

namespace CannabisMath.Core.Tests.Rounding;

public class RoundingCalculatorTests
{
    [Fact]
    public void RoundCurrency_RoundsToTwoDecimals()
    {
        var result = RoundingCalculator.RoundCurrency(10.125m);

        Assert.Equal(10.13m, result);
    }

    [Fact]
    public void RoundWeight_RoundsToThreeDecimals()
    {
        var result = RoundingCalculator.RoundWeight(3.4567m);

        Assert.Equal(3.457m, result);
    }

    [Fact]
    public void RoundMilligrams_RoundsToTwoDecimals()
    {
        var result = RoundingCalculator.RoundMilligrams(125.555m);

        Assert.Equal(125.56m, result);
    }

    [Fact]
    public void RoundPercent_RoundsToTwoDecimals()
    {
        var result = RoundingCalculator.RoundPercent(23.456m);

        Assert.Equal(23.46m, result);
    }

    [Theory]
    [InlineData("10.00", "10.00")]
    [InlineData("10.01", "10.00")]
    [InlineData("10.02", "10.00")]
    [InlineData("10.03", "10.05")]
    [InlineData("10.04", "10.05")]
    [InlineData("10.05", "10.05")]
    [InlineData("10.06", "10.05")]
    [InlineData("10.07", "10.05")]
    [InlineData("10.08", "10.10")]
    [InlineData("10.09", "10.10")]
    public void RoundCashToNearestNickel_RoundsCorrectly(string input, string expected)
    {
        var value = decimal.Parse(input);
        var expectedValue = decimal.Parse(expected);

        var result = RoundingCalculator.RoundCashToNearestNickel(value);

        Assert.Equal(expectedValue, result);
    }

    [Fact]
    public void RoundCashUpToNickel_RoundsUp()
    {
        var result = RoundingCalculator.RoundCashUpToNickel(10.01m);

        Assert.Equal(10.05m, result);
    }

    [Fact]
    public void RoundCashDownToNickel_RoundsDown()
    {
        var result = RoundingCalculator.RoundCashDownToNickel(10.09m);

        Assert.Equal(10.05m, result);
    }

    [Fact]
    public void RoundToIncrement_QuarterIncrementNearest_ReturnsCorrectValue()
    {
        var result = RoundingCalculator.RoundToIncrement(10.13m, 0.25m, RoundingMode.Nearest);

        Assert.Equal(10.25m, result);
    }

    [Fact]
    public void RoundToIncrement_WholeDollarDown_ReturnsCorrectValue()
    {
        var result = RoundingCalculator.RoundToIncrement(10.99m, 1m, RoundingMode.Down);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void RoundToIncrement_WholeDollarUp_ReturnsCorrectValue()
    {
        var result = RoundingCalculator.RoundToIncrement(10.01m, 1m, RoundingMode.Up);

        Assert.Equal(11m, result);
    }

    [Fact]
    public void RoundingDifference_ReturnsRoundedMinusOriginal()
    {
        var result = RoundingCalculator.RoundingDifference(10.03m, 10.05m);

        Assert.Equal(0.02m, result);
    }

    [Fact]
    public void RoundToIncrement_ZeroIncrement_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            RoundingCalculator.RoundToIncrement(10m, 0m, RoundingMode.Nearest));
    }

    [Fact]
    public void RoundToIncrement_NegativeIncrement_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            RoundingCalculator.RoundToIncrement(10m, -0.05m, RoundingMode.Nearest));
    }
}