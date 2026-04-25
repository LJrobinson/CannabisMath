using CannabisMath.Core.Rounding;

namespace CannabisMath.Core.Tests.Rounding;

public class RoundingResultTests
{
    [Fact]
    public void RoundWithResult_NearestNickel_ReturnsFullBreakdown()
    {
        var result = RoundingCalculator.RoundWithResult(
            value: 10.03m,
            increment: 0.05m,
            mode: RoundingMode.Nearest
        );

        Assert.Equal(10.03m, result.OriginalValue);
        Assert.Equal(10.05m, result.RoundedValue);
        Assert.Equal(0.02m, result.Difference);
        Assert.Equal(RoundingMode.Nearest, result.Mode);
        Assert.Equal(0.05m, result.Increment);
    }

    [Fact]
    public void RoundWithResult_RoundingDown_ReturnsNegativeDifference()
    {
        var result = RoundingCalculator.RoundWithResult(
            value: 10.09m,
            increment: 0.05m,
            mode: RoundingMode.Down
        );

        Assert.Equal(10.05m, result.RoundedValue);
        Assert.Equal(-0.04m, result.Difference);
    }

    [Fact]
    public void RoundWithResult_ExactValue_ReturnsZeroDifference()
    {
        var result = RoundingCalculator.RoundWithResult(
            value: 10.05m,
            increment: 0.05m,
            mode: RoundingMode.Nearest
        );

        Assert.Equal(0m, result.Difference);
    }
}