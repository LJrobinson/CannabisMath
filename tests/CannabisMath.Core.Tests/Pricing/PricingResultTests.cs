using CannabisMath.Core.Pricing;

namespace CannabisMath.Core.Tests.Pricing;

public class PricingResultTests
{
    [Fact]
    public void CalculatePricePerGramResult_ReturnsFullBreakdown()
    {
        var result = PriceCalculator.CalculatePricePerGramResult(35m, 3.5m);

        Assert.Equal(35m, result.Price);
        Assert.Equal(3.5m, result.Quantity);
        Assert.Equal(10m, result.UnitPrice);
        Assert.Equal("gram", result.UnitLabel);
    }

    [Fact]
    public void CalculatePricePerMgResult_ReturnsFullBreakdown()
    {
        var result = PriceCalculator.CalculatePricePerMgResult(25m, 500m);

        Assert.Equal(25m, result.Price);
        Assert.Equal(500m, result.Quantity);
        Assert.Equal(0.05m, result.UnitPrice);
        Assert.Equal("mg", result.UnitLabel);
    }
}