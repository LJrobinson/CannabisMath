# CannabisMath (Python)

CannabisMath is a cross-platform cannabis calculation library designed for accuracy, consistency, and real-world retail use.

This Python package provides deterministic calculations for:

- Potency (THC / CBD from COA values)
- Dosing (mg calculations)
- Weight conversions (grams, ounces, pounds)
- Pricing (price per gram / mg)
- Taxes
- Rounding (including POS-safe nickel rounding)
- Packaging and retail breakdowns
- Composite value calculations

---

## Installation

pip install cannabismath

---

## Quick Start

from cannabismath import PotencyCalculator

total_thc = PotencyCalculator.calculate_total_thc(1.2, 24.8)
print(total_thc)  # 22.9496

---

## Why CannabisMath?

Cannabis calculations are often inconsistent across apps, dashboards, and POS systems.

Differences in:
- rounding rules
- weight assumptions
- potency formulas
- tax handling

can lead to mismatched results and real operational issues.

CannabisMath provides a single, deterministic calculation layer to ensure consistent results across systems and languages.

---

## Cross-Platform Design

CannabisMath is designed to produce identical results across:

- C# (NuGet)
- TypeScript (NPM)
- Python (PyPI)

All implementations share the same test fixtures to guarantee parity.

---

## Example: Dosing

from cannabismath import DoseCalculator

total_mg = DoseCalculator.total_mg_from_percent(3.5, 20)
print(total_mg)  # 700

---

## Example: Rounding

from cannabismath import RoundingCalculator

rounded = RoundingCalculator.round_cash_to_nearest_nickel(10.03)
print(rounded)  # 10.05

---

## Test Integrity

CannabisMath uses shared JSON test fixtures across all languages to ensure:

- consistent outputs
- no drift between implementations
- predictable results for real-world usage

---

## Use Cases

- Dispensary POS systems
- Cannabis analytics dashboards
- Inventory and pricing tools
- Data pipelines and automation scripts
- Consumer-facing calculators

---

## Disclaimer

CannabisMath is a calculation library only.

It is not legal, tax, medical, or compliance advice.

Always verify calculations against local regulations.

---

## License

MIT
