using CannabisMath.Core.Packaging;

namespace CannabisMath.Core.Tests.Packaging;

public class PackageCalculatorTests
{
    [Fact]
    public void FullUnits_PoundToEighths_ReturnsCorrectCount()
    {
        var result = PackageCalculator.FullUnits(453.59237m, 3.5m);

        Assert.Equal(129, result);
    }

    [Fact]
    public void RemainingGrams_PoundToEighths_ReturnsCorrectRemainder()
    {
        var result = PackageCalculator.RemainingGrams(453.59237m, 3.5m);

        Assert.Equal(2.09237m, result);
    }

    [Fact]
    public void Breakdown_ReturnsUnitsAndRemainder()
    {
        var result = PackageCalculator.Breakdown(28m, 3.5m);

        Assert.Equal(8, result.fullUnits);
        Assert.Equal(0m, result.remainingGrams);
    }

    [Fact]
    public void ExactDivision_NoRemainder()
    {
        var result = PackageCalculator.RemainingGrams(14m, 7m);

        Assert.Equal(0m, result);
    }

    [Fact]
    public void NegativeInput_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PackageCalculator.FullUnits(-1m, 3.5m));
    }

    [Fact]
    public void ZeroUnitSize_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PackageCalculator.FullUnits(28m, 0m));
    }
}