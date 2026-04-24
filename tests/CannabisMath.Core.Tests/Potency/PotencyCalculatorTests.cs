using CannabisMath.Core.Potency;

namespace CannabisMath.Core.Tests.Potency;

public class PotencyCalculatorTests
{
    [Fact]
    public void CalculateTotalThc_ValidInput_ReturnsCorrectValue()
    {
        // Arrange
        decimal thc = 1.2m;
        decimal thca = 24.8m;

        // Act
        var result = PotencyCalculator.CalculateTotalThc(thc, thca);

        // Assert
        Assert.Equal(1.2m + (24.8m * 0.877m), result);
    }

    [Fact]
    public void CalculateTotalCbd_ValidInput_ReturnsCorrectValue()
    {
        decimal cbd = 0.5m;
        decimal cbda = 10.0m;

        var result = PotencyCalculator.CalculateTotalCbd(cbd, cbda);

        Assert.Equal(0.5m + (10.0m * 0.877m), result);
    }

    [Fact]
    public void CalculateTotalThc_NegativeInput_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PotencyCalculator.CalculateTotalThc(-1m, 10m));
    }
}