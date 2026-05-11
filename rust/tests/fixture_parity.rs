use serde::Deserialize;
use std::fs;

use cannabismath::{
    composite_price_per_mg_from_weight_and_potency, dab_mg, grams_to_retail_eighths,
    packaging_breakdown, pounds_to_grams, price_per_gram, price_per_mg,
    round_to_nearest_nickel, rounding_difference, tax_amount, total_cbd, total_mg_from_weight_and_potency,
    total_thc, total_with_combined_taxes,
};

const EPSILON: f64 = 0.0001;

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct CoreFixtures {
    potency: Vec<PotencyFixture>,
    weights: Vec<WeightFixture>,
    dosing: Vec<DosingFixture>,
    pricing: Vec<PricingFixture>,
    rounding: Vec<RoundingFixture>,
    taxes: Vec<TaxFixture>,
    packaging: Vec<PackagingFixture>,
    composites: Vec<CompositeFixture>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct PotencyFixture {
    name: String,
    thc_percent: Option<f64>,
    thca_percent: Option<f64>,
    expected_total_thc: Option<f64>,
    cbd_percent: Option<f64>,
    cbda_percent: Option<f64>,
    expected_total_cbd: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct WeightFixture {
    name: String,
    grams: Option<f64>,
    pounds: Option<f64>,
    expected_retail_eighths: Option<f64>,
    expected_grams: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct DosingFixture {
    name: String,
    weight_grams: Option<f64>,
    potency_percent: f64,
    dab_size_grams: Option<f64>,
    expected_total_mg: Option<f64>,
    expected_mg: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct PricingFixture {
    name: String,
    price: f64,
    grams: Option<f64>,
    total_mg: Option<f64>,
    expected_price_per_gram: Option<f64>,
    expected_price_per_mg: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct RoundingFixture {
    name: String,
    value: Option<f64>,
    expected_rounded: Option<f64>,
    original_value: Option<f64>,
    rounded_value: Option<f64>,
    expected_difference: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct TaxFixture {
    name: String,
    subtotal: f64,
    tax_rate_percent: Option<f64>,
    tax_rates: Option<Vec<f64>>,
    expected_tax_amount: Option<f64>,
    expected_total: Option<f64>,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct PackagingFixture {
    name: String,
    total_grams: f64,
    grams_per_unit: f64,
    expected_full_units: u64,
    expected_remaining_grams: f64,
}

#[derive(Debug, Deserialize)]
#[serde(rename_all = "camelCase")]
struct CompositeFixture {
    name: String,
    price: f64,
    weight_grams: f64,
    potency_percent: f64,
    expected_price_per_mg: f64,
}

fn assert_close(actual: f64, expected: f64, name: &str) {
    assert!(
        (actual - expected).abs() < EPSILON,
        "{name}: expected {expected}, got {actual}"
    );
}

fn load_fixtures() -> CoreFixtures {
    let json = fs::read_to_string("../shared/test-fixtures/core-fixtures.json")
        .expect("failed to read shared fixture file");

    serde_json::from_str(&json).expect("failed to parse shared fixture file")
}

#[test]
fn potency_matches_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.potency {
        if let Some(expected) = case.expected_total_thc {
            let actual = total_thc(
                case.thc_percent.unwrap_or(0.0),
                case.thca_percent.unwrap_or(0.0),
            );
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_total_cbd {
            let actual = total_cbd(
                case.cbd_percent.unwrap_or(0.0),
                case.cbda_percent.unwrap_or(0.0),
            );
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn weights_match_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.weights {
        if let Some(expected) = case.expected_retail_eighths {
            let actual = grams_to_retail_eighths(case.grams.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_grams {
            let actual = pounds_to_grams(case.pounds.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn dosing_matches_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.dosing {
        if let Some(expected) = case.expected_total_mg {
            let actual = total_mg_from_weight_and_potency(
                case.weight_grams.unwrap_or(0.0),
                case.potency_percent,
            );
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_mg {
            let actual = dab_mg(case.potency_percent, case.dab_size_grams.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn pricing_matches_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.pricing {
        if let Some(expected) = case.expected_price_per_gram {
            let actual = price_per_gram(case.price, case.grams.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_price_per_mg {
            let actual = price_per_mg(case.price, case.total_mg.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn rounding_matches_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.rounding {
        if let Some(expected) = case.expected_rounded {
            let actual = round_to_nearest_nickel(case.value.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_difference {
            let actual = rounding_difference(
                case.original_value.unwrap_or(0.0),
                case.rounded_value.unwrap_or(0.0),
            );
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn taxes_match_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.taxes {
        if let Some(expected) = case.expected_tax_amount {
            let actual = tax_amount(case.subtotal, case.tax_rate_percent.unwrap_or(0.0));
            assert_close(actual, expected, &case.name);
        }

        if let Some(expected) = case.expected_total {
            let tax_rates = case.tax_rates.unwrap_or_default();
            let actual = total_with_combined_taxes(case.subtotal, &tax_rates);
            assert_close(actual, expected, &case.name);
        }
    }
}

#[test]
fn packaging_matches_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.packaging {
        let actual = packaging_breakdown(case.total_grams, case.grams_per_unit);

        assert_eq!(
            actual.full_units, case.expected_full_units,
            "{}: expected {} full units, got {}",
            case.name, case.expected_full_units, actual.full_units
        );

        assert_close(
            actual.remaining_grams,
            case.expected_remaining_grams,
            &case.name,
        );
    }
}

#[test]
fn composites_match_shared_fixtures() {
    let fixtures = load_fixtures();

    for case in fixtures.composites {
        let actual = composite_price_per_mg_from_weight_and_potency(
            case.price,
            case.weight_grams,
            case.potency_percent,
        );

        assert_close(actual, case.expected_price_per_mg, &case.name);
    }
}