# CannabisMath

![.NET](https://img.shields.io/badge/.NET-8-blue)
![Tests](https://img.shields.io/badge/tests-68%20passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-green)

**CannabisMath** is a C# cannabis calculation library for potency, dosing, weight conversions, pricing, packaging, taxes, rounding, and retail value calculations.

Built for cannabis apps, dashboards, dispensary tooling, POS workflows, inventory systems, calculators, and data projects.

> Reliable weed math. Tested, reusable, and ready to port.

---

## Status

Current version: **v0.1.0**

CannabisMath is an early-stage library with a stable core calculation engine.

---

## Quick Start

```csharp
using CannabisMath.Core.Composites;

var pricePerMg = CannabisValueCalculator.PricePerMgFromWeightAndPotency(
    price: 35m,
    weightGrams: 3.5m,
    potencyPercent: 20m
);
// 0.05
```

---

## Why CannabisMath?

Cannabis calculations are often inconsistent across apps, dashboards, and POS systems. Differences in rounding, weight assumptions, potency formulas, and tax handling can lead to mismatched results and operational issues.

CannabisMath provides a single, deterministic calculation layer to ensure consistent results across systems.

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

---

## Project Structure

```txt
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
```

---

## Installation

This project is not published to NuGet yet.

For now, clone the repo and reference the project locally:

```bash
git clone https://github.com/LJrobinson/CannabisMath.git
```

Then add a project reference from another C# project:

```bash
dotnet add reference path/to/CannabisMath/src/CannabisMath.Core/CannabisMath.Core.csproj
```

---

## Examples

### Potency

```csharp
using CannabisMath.Core.Potency;

var totalThc = PotencyCalculator.CalculateTotalThc(
    thcPercent: 1.2m,
    thcaPercent: 24.8m
);
```

### Weight Conversions

```csharp
using CannabisMath.Core.Weights;

var eighths = WeightConverter.GramsToRetailEighths(28m);
```

### Dosing

```csharp
using CannabisMath.Core.Dosing;

var totalMg = DoseCalculator.TotalMgFromPercent(3.5m, 20m);
```

### Pricing

```csharp
using CannabisMath.Core.Pricing;

var pricePerGram = PriceCalculator.PricePerGram(35m, 3.5m);
```

### Packaging

```csharp
using CannabisMath.Core.Packaging;

var breakdown = PackageCalculator.Breakdown(453.59237m, 3.5m);
```

### Rounding

```csharp
using CannabisMath.Core.Rounding;

var cashTotal = RoundingCalculator.RoundCashToNearestNickel(10.03m);
```

---

## Test Coverage

Run all tests:

```bash
dotnet test
```

Current test count:

68 passing tests

---

## Design Goals

- Simple to use
- Deterministic
- Well-tested
- Decimal-based for financial and retail calculations
- Easy to port to JavaScript and Python
- Useful for real cannabis retail workflows

---

## Roadmap

- NuGet package publishing
- JavaScript / TypeScript port
- Python port
- Shared cross-language test fixtures
- Result models / DTOs
- Jurisdiction-aware tax configs
- Margin and promo math

---

## Disclaimer

CannabisMath is a calculation library, not legal or tax advice.

---

## License

MIT
