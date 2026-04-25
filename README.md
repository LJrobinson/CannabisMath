# CannabisMath

**CannabisMath** is a C# cannabis calculation library for potency, dosing, weight conversions, pricing, packaging, taxes, rounding, and retail value calculations.

Built for cannabis apps, dashboards, dispensary tooling, POS workflows, inventory systems, calculators, and data projects.

> Reliable weed math. Tested, reusable, and ready to port.

---

## Status

Current version: **v0.1.0**

CannabisMath is early but functional. The current release focuses on pure calculation logic with unit tests.

---

## Features

- **Potency calculations**
  - Total THC from THC + THCA
  - Total CBD from CBD + CBDA

- **Weight conversions**
  - Grams to retail eighths
  - Retail eighths to grams
  - Retail ounces to grams
  - Exact ounces and pounds

- **Dosing calculations**
  - Milligrams per serving
  - Total mg from weight and potency
  - Mg per gram
  - Dab mg estimates

- **Pricing calculations**
  - Price per gram
  - Price per mg
  - Discounted price
  - Savings amount

- **Packaging calculations**
  - Full sellable units from bulk weight
  - Remaining grams
  - Bulk-to-retail breakdowns

- **Composite value calculations**
  - Price per mg from weight and potency
  - Price per gram after discount
  - Price per mg after discount

- **Tax calculations**
  - Tax amount
  - Total with tax
  - Combined tax rates
  - Decimal rate support

- **Rounding utilities**
  - Currency rounding
  - Weight rounding
  - Milligram rounding
  - Percent rounding
  - Cash rounding to nearest nickel
  - Round up/down to nickel
  - Custom increment rounding
  - Rounding difference tracking



## Project Structure


CannabisMath/
  src/
    CannabisMath.Core/
      Composites/
      Dosing/
      Packaging/
      Potency/
      Pricing/
      Rounding/
      Taxes/
      Weights/

  tests/
    CannabisMath.Core.Tests/
      Composites/
      Dosing/
      Packaging/
      Potency/
      Pricing/
      Rounding/
      Taxes/
      Weights/


---

## Installation

This project is not published to NuGet yet.

For now, clone the repo and reference the project locally:

bash
git clone https://github.com/LJrobinson/CannabisMath.git


Then add a project reference from another C# project:

bash
dotnet add reference path/to/CannabisMath/src/CannabisMath.Core/CannabisMath.Core.csproj


---

## Usage Examples

### Potency

csharp
using CannabisMath.Core.Potency;

var totalThc = PotencyCalculator.CalculateTotalThc(
    thcPercent: 1.2m,
    thcaPercent: 24.8m
);


Formula:

Total THC = THC + (THCA × 0.877)


---

### Weight Conversions

csharp
using CannabisMath.Core.Weights;

var eighths = WeightConverter.GramsToRetailEighths(28m);
// 8


csharp
var grams = WeightConverter.ExactPoundsToGrams(1m);
// 453.59237


---

### Dosing

csharp
using CannabisMath.Core.Dosing;

var totalMg = DoseCalculator.TotalMgFromPercent(
    weightGrams: 3.5m,
    potencyPercent: 20m
);
// 700mg


csharp
var dabMg = DoseCalculator.DabMg(
    potencyPercent: 80m,
    dabSizeGrams: 0.05m
);
// 40mg


---

### Pricing

csharp
using CannabisMath.Core.Pricing;

var pricePerGram = PriceCalculator.PricePerGram(
    price: 35m,
    grams: 3.5m
);
// 10


csharp
var pricePerMg = PriceCalculator.PricePerMg(
    price: 25m,
    totalMg: 500m
);
// 0.05


---

### Packaging

csharp
using CannabisMath.Core.Packaging;

var breakdown = PackageCalculator.Breakdown(
    totalGrams: 453.59237m,
    gramsPerUnit: 3.5m
);

// breakdown.fullUnits = 129
// breakdown.remainingGrams = 2.09237


---

### Composite Value Calculations

csharp
using CannabisMath.Core.Composites;

var pricePerMg = CannabisValueCalculator.PricePerMgFromWeightAndPotency(
    price: 35m,
    weightGrams: 3.5m,
    potencyPercent: 20m
);
// 0.05


---

### Taxes

csharp
using CannabisMath.Core.Taxes;

var tax = TaxCalculator.TaxAmount(
    subtotal: 100m,
    taxRatePercent: 8.375m
);
// 8.375


csharp
var total = TaxCalculator.TotalWithCombinedTaxes(
    subtotal: 100m,
    10m,
    8.375m
);
// 118.375


---

### Rounding

csharp
using CannabisMath.Core.Rounding;

var rounded = RoundingCalculator.RoundCurrency(10.125m);
// 10.13


csharp
var cashTotal = RoundingCalculator.RoundCashToNearestNickel(10.03m);
// 10.05


csharp
var difference = RoundingCalculator.RoundingDifference(
    originalValue: 10.03m,
    roundedValue: 10.05m
);
// 0.02


---

## Retail vs Exact Weight

Cannabis retail commonly uses rounded package weights:

1 eighth = 3.5g
1 quarter = 7g
1 half ounce = 14g
1 ounce = 28g


Scientific/legal conversions use exact weights:

1 ounce = 28.349523125g
1 pound = 453.59237g


CannabisMath supports both.

---

## Test Coverage

Run all tests:

bash
dotnet test


Current test count:

68 passing tests


---

## Design Goals

CannabisMath is designed to be:

* Simple to use
* Deterministic
* Well-tested
* Decimal-based for financial and retail calculations
* Easy to port to JavaScript, Python, and other languages
* Useful for real cannabis retail, analytics, and inventory workflows

---

## Roadmap

Planned future work:

* NuGet package publishing
* JavaScript / TypeScript port
* Python port
* Shared cross-language test fixtures
* Result models / DTOs
* Jurisdiction-aware tax configs
* Nevada cannabis tax helpers
* More COA / lab result calculations
* Margin and markup calculations
* Bundle and promo math
* Inventory depletion helpers

---

## Disclaimer

CannabisMath is a calculation library, not legal, tax, compliance, medical, or financial advice.

Cannabis laws, tax rates, labeling rules, and compliance requirements vary by jurisdiction and may change over time. Always verify results against current local regulations and official guidance.

---

## License

MIT

