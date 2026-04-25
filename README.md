# CannabisMath

![.NET](https://img.shields.io/badge/.NET-8-blue)
![NuGet](https://img.shields.io/nuget/v/CannabisMath.Core)
![Tests](https://img.shields.io/badge/tests-132%20passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-green)

**CannabisMath** is a cross-platform cannabis calculation library for potency, dosing, weight conversions, pricing, packaging, taxes, rounding, and retail value calculations.

Built for cannabis apps, dashboards, dispensary tooling, POS workflows, inventory systems, calculators, and data projects.

> Reliable weed math. Tested, reusable, and consistent across languages.

---

## Status

Current version: **v0.1.0**

- C# library published to NuGet
- TypeScript port complete (in `/js`)
- Full parity between C# and JS logic
- 130+ combined tests across both implementations

---

## Quick Start (C#)

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

## Quick Start (TypeScript)

```ts
import { CannabisValueCalculator } from "./js/src/composites/cannabisValueCalculator";

const result = CannabisValueCalculator.pricePerMgFromWeightAndPotency(
  35,
  3.5,
  20
);
// 0.05
```

---

## Why CannabisMath?

Cannabis calculations are often inconsistent across apps, dashboards, and POS systems. Differences in rounding, weight assumptions, potency formulas, and tax handling can lead to mismatched results and operational issues.

CannabisMath provides a single, deterministic calculation layer to ensure consistent results across systems and languages.

---

## Cross-Language Consistency

This project maintains identical calculation logic across:

- C# (.NET / NuGet)
- TypeScript (Node / Web)

Same inputs → same outputs → everywhere.

---

## Project Structure

```
CannabisMath/
  src/ (C# core library)
  tests/ (C# tests)

  js/
    src/ (TypeScript implementation)
    tests/ (Vitest)
```

---

## Installation

### C#

```bash
dotnet add package CannabisMath.Core
```

### TypeScript (coming soon to NPM)

```bash
npm install cannabismath
```

---

## Test Coverage

- C#: 68 tests
- TypeScript: 64 tests

Total: 130+ passing tests

---

## Roadmap

- NPM package publish
- Python port
- Shared cross-language test fixtures
- Jurisdiction-aware tax configs
- POS rounding strategies
- Advanced pricing & margin tools

---

## Disclaimer

CannabisMath is a calculation library, not legal or tax advice.

---

## License

MIT