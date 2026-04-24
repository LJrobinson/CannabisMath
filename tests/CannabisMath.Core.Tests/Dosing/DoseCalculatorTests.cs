using CannabisMath.Core.Dosing;

namespace CannabisMath.Core.Tests.Dosing;

public class DoseCalculatorTests
{
    [Fact]
    public void MgPerServing_ValidInput_ReturnsCorrectValue()
    {
        var result = DoseCalculator.MgPerServing(100m, 10m);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void TotalMgFromPercent_OneGramAtTwentyFivePercent_ReturnsTwoHundredFiftyMg()
    {
        var result = DoseCalculator.TotalMgFromPercent(1m, 25m);

        Assert.Equal(250m, result);
    }

    [Fact]
    public void MgPerGram_TwentyFivePercent_ReturnsTwoHundredFiftyMg()
    {
        var result = DoseCalculator.MgPerGram(25m);

        Assert.Equal(250m, result);
    }

    [Fact]
    public void DabMg_PointZeroFiveGramAtEightyPercent_ReturnsFortyMg()
    {
        var result = DoseCalculator.DabMg(80m, 0.05m);

        Assert.Equal(40m, result);
    }

    [Fact]
    public void MgPerServing_ZeroServings_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            DoseCalculator.MgPerServing(100m, 0m));
    }

    [Fact]
    public void NegativeWeight_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            DoseCalculator.TotalMgFromPercent(-1m, 25m));
    }

    [Fact]
    public void NegativePotency_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            DoseCalculator.MgPerGram(-25m));
    }
}