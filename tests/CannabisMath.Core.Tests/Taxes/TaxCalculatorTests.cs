using CannabisMath.Core.Taxes;

namespace CannabisMath.Core.Tests.Taxes;

public class TaxCalculatorTests
{
    [Fact]
    public void TaxAmount_TenPercent_ReturnsCorrectTax()
    {
        var result = TaxCalculator.TaxAmount(100m, 10m);

        Assert.Equal(10m, result);
    }

    [Fact]
    public void TotalWithTax_TenPercent_ReturnsCorrectTotal()
    {
        var result = TaxCalculator.TotalWithTax(100m, 10m);

        Assert.Equal(110m, result);
    }

    [Fact]
    public void CombinedTaxRate_MultipleRates_ReturnsSum()
    {
        var result = TaxCalculator.CombinedTaxRate(10m, 8.375m, 1m);

        Assert.Equal(19.375m, result);
    }

    [Fact]
    public void TotalWithCombinedTaxes_MultipleRates_ReturnsCorrectTotal()
    {
        var result = TaxCalculator.TotalWithCombinedTaxes(100m, 10m, 8.375m);

        Assert.Equal(118.375m, result);
    }

    [Fact]
    public void TaxAmountFromRate_DecimalRate_ReturnsCorrectTax()
    {
        var result = TaxCalculator.TaxAmountFromRate(100m, 0.08375m);

        Assert.Equal(8.375m, result);
    }

    [Fact]
    public void TotalWithTaxRate_DecimalRate_ReturnsCorrectTotal()
    {
        var result = TaxCalculator.TotalWithTaxRate(100m, 0.08375m);

        Assert.Equal(108.375m, result);
    }

    [Fact]
    public void NegativeSubtotal_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            TaxCalculator.TaxAmount(-1m, 10m));
    }

    [Fact]
    public void PercentOverOneHundred_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            TaxCalculator.TaxAmount(100m, 101m));
    }

    [Fact]
    public void DecimalRateOverOne_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            TaxCalculator.TaxAmountFromRate(100m, 1.1m));
    }

    [Fact]
    public void NullCombinedTaxRates_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            TaxCalculator.CombinedTaxRate(null!));
    }
}