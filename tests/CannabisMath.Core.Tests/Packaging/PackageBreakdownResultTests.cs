using CannabisMath.Core.Packaging;

namespace CannabisMath.Core.Tests.Packaging;

public class PackageBreakdownResultTests
{
    [Fact]
    public void CalculateBreakdownResult_ReturnsFullBreakdown()
    {
        var result = PackageCalculator.CalculateBreakdownResult(453.59237m, 3.5m);

        Assert.Equal(453.59237m, result.TotalGrams);
        Assert.Equal(3.5m, result.GramsPerUnit);
        Assert.Equal(129, result.FullUnits);
        Assert.Equal(2.09237m, result.RemainingGrams);
    }
}