# CannabisMath

CannabisMath is a cross-platform cannabis calculation engine built for accuracy, consistency, and real-world retail workflows.

It provides deterministic cannabis calculations across:

- C# / .NET
- TypeScript / JavaScript
- Python
- Rust
- Kotlin / JVM

All implementations are validated against shared JSON fixtures to ensure identical results across every platform.

## Why CannabisMath?

Cannabis calculations are often inconsistent across systems.

Small differences in:

- rounding rules
- potency formulas
- weight assumptions
- tax handling
- packaging logic

can lead to mismatched totals, POS errors, reporting issues, and customer frustration.

CannabisMath provides a single source of truth for common cannabis retail and compliance math.

## Features

- Potency calculations
- THC / CBD total calculations
- Weight conversions
- Dosing calculations
- Pricing logic
- Tax calculations
- Rounding utilities
- Nickel rounding
- Packaging breakdowns
- Composite calculations

## Installation

### C# / .NET

```bash
dotnet add package CannabisMath.Core
```

### TypeScript / JavaScript

```bash
npm install @ljrobinson/cannabismath
```

### Python

```bash
pip install cannabismath
```

### Rust

```bash
cd rust
cargo test
cargo run --example basic_usage
```

### Kotlin / JVM

```bash
cd kotlin
./gradlew test
```

## Example

### Python

```python
from cannabismath import CannabisValueCalculator

value = CannabisValueCalculator.price_per_mg_from_weight_and_potency(
    price=35,
    weight_grams=3.5,
    potency_percent=20
)

print(value)
```

Output:

```text
0.05
```

## Architecture

CannabisMath uses shared JSON fixtures to validate behavior across every supported language implementation.

The same fixture data is used to test:

- C#
- TypeScript
- Python
- Rust
- Kotlin

This helps prevent calculation drift between platforms.

## Use Cases

CannabisMath can be used in:

- POS systems
- analytics dashboards
- inventory tools
- data pipelines
- pricing tools
- consumer calculators
- compliance-adjacent internal tools

## Disclaimer

CannabisMath is a calculation library only.

It does not provide legal, regulatory, medical, tax, or compliance advice. Users are responsible for validating calculations against their own jurisdiction, business rules, and reporting requirements.

## License

MIT
