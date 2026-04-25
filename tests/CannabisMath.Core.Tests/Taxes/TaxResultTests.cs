using CannabisMath.Core.Taxes;

namespace CannabisMath.Core.Tests.Taxes;

public class TaxResultTests
{
    [Fact]
    public void CalculateTaxResult_ReturnsFullBreakdown()
    {
        var result = TaxCalculator.CalculateTaxResult(100m, 8.375m);

        Assert.Equal(100m, result.Subtotal);
        Assert.Equal(8.375m, result.TaxRatePercent);
        Assert.Equal(8.375m, result.TaxAmount);
        Assert.Equal(108.375m, result.Total);
    }
}