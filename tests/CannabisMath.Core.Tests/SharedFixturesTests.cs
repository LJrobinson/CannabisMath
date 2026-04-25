using System.Text.Json;
using CannabisMath.Core.Composites;
using CannabisMath.Core.Dosing;
using CannabisMath.Core.Packaging;
using CannabisMath.Core.Potency;
using CannabisMath.Core.Pricing;
using CannabisMath.Core.Rounding;
using CannabisMath.Core.Taxes;
using CannabisMath.Core.Weights;

namespace CannabisMath.Core.Tests;

public class SharedFixturesTests
{
    private static readonly CoreFixtures Fixtures = LoadFixtures();

    [Fact]
    public void PotencyFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Potency)
        {
            if (fixture.ExpectedTotalThc is not null)
            {
                var result = PotencyCalculator.CalculateTotalThc(
                    fixture.ThcPercent!.Value,
                    fixture.ThcaPercent!.Value
                );

                Assert.Equal(fixture.ExpectedTotalThc.Value, result);
            }

            if (fixture.ExpectedTotalCbd is not null)
            {
                var result = PotencyCalculator.CalculateTotalCbd(
                    fixture.CbdPercent!.Value,
                    fixture.CbdaPercent!.Value
                );

                Assert.Equal(fixture.ExpectedTotalCbd.Value, result);
            }
        }
    }

    [Fact]
    public void WeightFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Weights)
        {
            if (fixture.ExpectedRetailEighths is not null)
            {
                var result = WeightConverter.GramsToRetailEighths(fixture.Grams!.Value);

                Assert.Equal(fixture.ExpectedRetailEighths.Value, result);
            }

            if (fixture.ExpectedGrams is not null)
            {
                var result = WeightConverter.ExactPoundsToGrams(fixture.Pounds!.Value);

                Assert.Equal(fixture.ExpectedGrams.Value, result);
            }
        }
    }

    [Fact]
    public void DosingFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Dosing)
        {
            if (fixture.ExpectedTotalMg is not null)
            {
                var result = DoseCalculator.TotalMgFromPercent(
                    fixture.WeightGrams!.Value,
                    fixture.PotencyPercent
                );

                Assert.Equal(fixture.ExpectedTotalMg.Value, result);
            }

            if (fixture.ExpectedMg is not null)
            {
                var result = DoseCalculator.DabMg(
                    fixture.PotencyPercent,
                    fixture.DabSizeGrams!.Value
                );

                Assert.Equal(fixture.ExpectedMg.Value, result);
            }
        }
    }

    [Fact]
    public void PricingFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Pricing)
        {
            if (fixture.ExpectedPricePerGram is not null)
            {
                var result = PriceCalculator.PricePerGram(
                    fixture.Price,
                    fixture.Grams!.Value
                );

                Assert.Equal(fixture.ExpectedPricePerGram.Value, result);
            }

            if (fixture.ExpectedPricePerMg is not null)
            {
                var result = PriceCalculator.PricePerMg(
                    fixture.Price,
                    fixture.TotalMg!.Value
                );

                Assert.Equal(fixture.ExpectedPricePerMg.Value, result);
            }
        }
    }

    [Fact]
    public void RoundingFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Rounding)
        {
            if (fixture.ExpectedRounded is not null)
            {
                var result = RoundingCalculator.RoundCashToNearestNickel(
                    fixture.Value!.Value
                );

                Assert.Equal(fixture.ExpectedRounded.Value, result);
            }

            if (fixture.ExpectedDifference is not null)
            {
                var result = RoundingCalculator.RoundingDifference(
                    fixture.OriginalValue!.Value,
                    fixture.RoundedValue!.Value
                );

                Assert.Equal(fixture.ExpectedDifference.Value, result);
            }
        }
    }

    [Fact]
    public void TaxFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Taxes)
        {
            if (fixture.ExpectedTaxAmount is not null)
            {
                var result = TaxCalculator.TaxAmount(
                    fixture.Subtotal,
                    fixture.TaxRatePercent!.Value
                );

                Assert.Equal(fixture.ExpectedTaxAmount.Value, result);
            }

            if (fixture.ExpectedTotal is not null)
            {
                var result = TaxCalculator.TotalWithCombinedTaxes(
                    fixture.Subtotal,
                    fixture.TaxRates!.ToArray()
                );

                Assert.Equal(fixture.ExpectedTotal.Value, result);
            }
        }
    }

    [Fact]
    public void PackagingFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Packaging)
        {
            var result = PackageCalculator.CalculateBreakdownResult(
                fixture.TotalGrams,
                fixture.GramsPerUnit
            );

            Assert.Equal(fixture.ExpectedFullUnits, result.FullUnits);
            Assert.Equal(fixture.ExpectedRemainingGrams, result.RemainingGrams);
        }
    }

    [Fact]
    public void CompositeFixtures_MatchExpectedValues()
    {
        foreach (var fixture in Fixtures.Composites)
        {
            var result = CannabisValueCalculator.PricePerMgFromWeightAndPotency(
                fixture.Price,
                fixture.WeightGrams,
                fixture.PotencyPercent
            );

            Assert.Equal(fixture.ExpectedPricePerMg, result);
        }
    }

    private static CoreFixtures LoadFixtures()
    {
        var fixturePath = Path.GetFullPath(
            Path.Combine(
                AppContext.BaseDirectory,
                "..", "..", "..", "..", "..",
                "shared",
                "test-fixtures",
                "core-fixtures.json"
            )
        );

        var json = File.ReadAllText(fixturePath);

        return JsonSerializer.Deserialize<CoreFixtures>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        ) ?? throw new InvalidOperationException("Could not load shared fixture file.");
    }

    private sealed class CoreFixtures
    {
        public List<PotencyFixture> Potency { get; set; } = [];
        public List<WeightFixture> Weights { get; set; } = [];
        public List<DosingFixture> Dosing { get; set; } = [];
        public List<PricingFixture> Pricing { get; set; } = [];
        public List<RoundingFixture> Rounding { get; set; } = [];
        public List<TaxFixture> Taxes { get; set; } = [];
        public List<PackagingFixture> Packaging { get; set; } = [];
        public List<CompositeFixture> Composites { get; set; } = [];
    }

    private sealed class PotencyFixture
    {
        public decimal? ThcPercent { get; set; }
        public decimal? ThcaPercent { get; set; }
        public decimal? ExpectedTotalThc { get; set; }
        public decimal? CbdPercent { get; set; }
        public decimal? CbdaPercent { get; set; }
        public decimal? ExpectedTotalCbd { get; set; }
    }

    private sealed class WeightFixture
    {
        public decimal? Grams { get; set; }
        public decimal? ExpectedRetailEighths { get; set; }
        public decimal? Pounds { get; set; }
        public decimal? ExpectedGrams { get; set; }
    }

    private sealed class DosingFixture
    {
        public decimal? WeightGrams { get; set; }
        public decimal PotencyPercent { get; set; }
        public decimal? ExpectedTotalMg { get; set; }
        public decimal? DabSizeGrams { get; set; }
        public decimal? ExpectedMg { get; set; }
    }

    private sealed class PricingFixture
    {
        public decimal Price { get; set; }
        public decimal? Grams { get; set; }
        public decimal? ExpectedPricePerGram { get; set; }
        public decimal? TotalMg { get; set; }
        public decimal? ExpectedPricePerMg { get; set; }
    }

    private sealed class RoundingFixture
    {
        public decimal? Value { get; set; }
        public decimal? ExpectedRounded { get; set; }
        public decimal? OriginalValue { get; set; }
        public decimal? RoundedValue { get; set; }
        public decimal? ExpectedDifference { get; set; }
    }

    private sealed class TaxFixture
    {
        public decimal Subtotal { get; set; }
        public decimal? TaxRatePercent { get; set; }
        public decimal? ExpectedTaxAmount { get; set; }
        public List<decimal>? TaxRates { get; set; }
        public decimal? ExpectedTotal { get; set; }
    }

    private sealed class PackagingFixture
    {
        public decimal TotalGrams { get; set; }
        public decimal GramsPerUnit { get; set; }
        public int ExpectedFullUnits { get; set; }
        public decimal ExpectedRemainingGrams { get; set; }
    }

    private sealed class CompositeFixture
    {
        public decimal Price { get; set; }
        public decimal WeightGrams { get; set; }
        public decimal PotencyPercent { get; set; }
        public decimal ExpectedPricePerMg { get; set; }
    }
}