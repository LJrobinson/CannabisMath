# CannabisMath Rust

Rust implementation of CannabisMath cannabis calculation utilities.

This package provides deterministic cannabis calculations for:

- potency
- weights
- dosing
- pricing
- rounding
- taxes
- packaging
- composite calculations

The Rust implementation is validated against the shared CannabisMath fixture suite at:

```text
../shared/test-fixtures/core-fixtures.json
```

## Run Tests

```bash
cargo test
```

## Run Example

```bash
cargo run --example basic_usage
```

## Example

```rust
use cannabismath::{total_thc, price_per_mg_from_weight_and_potency};

fn main() {
    let total_thc_percent = total_thc(1.2, 24.8);
    let price_per_mg = price_per_mg_from_weight_and_potency(35.0, 3.5, 20.0);

    println!("Total THC: {:.4}%", total_thc_percent);
    println!("Price per mg THC: ${:.4}", price_per_mg);
}
```

## Fixture Parity

The Rust implementation includes integration tests that load the shared JSON fixture file and validate results against the same expected values used by the other CannabisMath implementations.

Current fixture categories:

- potency
- weights
- dosing
- pricing
- rounding
- taxes
- packaging
- composites

## Package Status

This Rust implementation is currently available in-repo.

Publishing to crates.io can be added later.
