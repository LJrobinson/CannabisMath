using CannabisMath.Core.Weights;

namespace CannabisMath.Core.Tests.Weights;

public class WeightConverterTests
{
    [Fact]
    public void GramsToRetailEighths_ConvertsCorrectly()
    {
        var result = WeightConverter.GramsToRetailEighths(28m);

        Assert.Equal(8m, result);
    }

    [Fact]
    public void RetailEighthsToGrams_ConvertsCorrectly()
    {
        var result = WeightConverter.RetailEighthsToGrams(8m);

        Assert.Equal(28m, result);
    }

    [Fact]
    public void GramsToRetailOunces_ConvertsCorrectly()
    {
        var result = WeightConverter.GramsToRetailOunces(28m);

        Assert.Equal(1m, result);
    }

    [Fact]
    public void RetailOuncesToGrams_ConvertsCorrectly()
    {
        var result = WeightConverter.RetailOuncesToGrams(1m);

        Assert.Equal(28m, result);
    }

    [Fact]
    public void ExactPoundsToGrams_ConvertsCorrectly()
    {
        var result = WeightConverter.ExactPoundsToGrams(1m);

        Assert.Equal(453.59237m, result);
    }

    [Fact]
    public void GramsToExactPounds_ConvertsCorrectly()
    {
        var result = WeightConverter.GramsToExactPounds(453.59237m);

        Assert.Equal(1m, result);
    }

    [Fact]
    public void NegativeWeight_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            WeightConverter.GramsToRetailEighths(-1m));
    }
}