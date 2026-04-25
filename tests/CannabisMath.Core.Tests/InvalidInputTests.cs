using CannabisMath.Core.Composites;
using CannabisMath.Core.Dosing;
using CannabisMath.Core.Packaging;
using CannabisMath.Core.Potency;
using CannabisMath.Core.Pricing;
using CannabisMath.Core.Rounding;
using CannabisMath.Core.Taxes;
using CannabisMath.Core.Weights;

namespace CannabisMath.Core.Tests;

public class InvalidInputTests
{
    [Fact]
    public void Potency_Rejects_Negative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PotencyCalculator.CalculateTotalThc(-1m, 10m));
    }

    [Fact]
    public void Weights_Reject_Negative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            WeightConverter.GramsToRetailEighths(-1m));
    }

    [Fact]
    public void Dosing_Rejects_Negative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            DoseCalculator.TotalMgFromPercent(-1m, 20m));
    }

    [Fact]
    public void Pricing_Rejects_Zero_Grams()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PriceCalculator.PricePerGram(35m, 0m));
    }

    [Fact]
    public void Rounding_Rejects_Zero_Increment()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            RoundingCalculator.RoundToIncrement(10m, 0m, RoundingMode.Nearest));
    }

    [Fact]
    public void Taxes_Reject_Negative_Subtotal()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            TaxCalculator.TaxAmount(-100m, 8.375m));
    }

    [Fact]
    public void Packaging_Rejects_Zero_Unit()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            PackageCalculator.Breakdown(28m, 0m));
    }

    [Fact]
    public void Composites_Reject_Zero_Potency()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            CannabisValueCalculator.PricePerMgFromWeightAndPotency(
                35m,
                3.5m,
                0m
            ));
    }
}