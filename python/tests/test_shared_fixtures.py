import json
from pathlib import Path

import pytest

from cannabismath import (
    PotencyCalculator,
    WeightConverter,
    DoseCalculator,
    PriceCalculator,
    RoundingCalculator,
    TaxCalculator,
    PackageCalculator,
    CannabisValueCalculator,
)


def load_fixtures():
    fixture_path = (
        Path(__file__).resolve().parents[2]
        / "shared"
        / "test-fixtures"
        / "core-fixtures.json"
    )

    with fixture_path.open("r", encoding="utf-8") as file:
        return json.load(file)


def test_potency_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["potency"]:
        if "expectedTotalThc" in fixture:
            result = PotencyCalculator.calculate_total_thc(
                fixture["thcPercent"],
                fixture["thcaPercent"],
            )

            assert result == pytest.approx(fixture["expectedTotalThc"])

        if "expectedTotalCbd" in fixture:
            result = PotencyCalculator.calculate_total_cbd(
                fixture["cbdPercent"],
                fixture["cbdaPercent"],
            )

            assert result == pytest.approx(fixture["expectedTotalCbd"])

def test_weight_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["weights"]:
        if "expectedRetailEighths" in fixture:
            result = WeightConverter.grams_to_retail_eighths(
                fixture["grams"]
            )

            assert result == pytest.approx(fixture["expectedRetailEighths"])

        if "expectedGrams" in fixture:
            result = WeightConverter.exact_pounds_to_grams(
                fixture["pounds"]
            )

            assert result == pytest.approx(fixture["expectedGrams"])

def test_dosing_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["dosing"]:
        if "expectedTotalMg" in fixture:
            result = DoseCalculator.total_mg_from_percent(
                fixture["weightGrams"],
                fixture["potencyPercent"]
            )

            assert result == pytest.approx(fixture["expectedTotalMg"])

        if "expectedMg" in fixture:
            result = DoseCalculator.dab_mg(
                fixture["potencyPercent"],
                fixture["dabSizeGrams"]
            )

            assert result == pytest.approx(fixture["expectedMg"])

def test_pricing_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["pricing"]:
        if "expectedPricePerGram" in fixture:
            result = PriceCalculator.price_per_gram(
                fixture["price"],
                fixture["grams"]
            )

            assert result == pytest.approx(fixture["expectedPricePerGram"])

        if "expectedPricePerMg" in fixture:
            result = PriceCalculator.price_per_mg(
                fixture["price"],
                fixture["totalMg"]
            )

            assert result == pytest.approx(fixture["expectedPricePerMg"])

def test_rounding_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["rounding"]:
        if "expectedRounded" in fixture:
            result = RoundingCalculator.round_cash_to_nearest_nickel(
                fixture["value"]
            )

            assert result == pytest.approx(fixture["expectedRounded"])

        if "expectedDifference" in fixture:
            result = RoundingCalculator.rounding_difference(
                fixture["originalValue"],
                fixture["roundedValue"]
            )

            assert result == pytest.approx(fixture["expectedDifference"])

def test_tax_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["taxes"]:
        if "expectedTaxAmount" in fixture:
            result = TaxCalculator.tax_amount(
                fixture["subtotal"],
                fixture["taxRatePercent"]
            )

            assert result == pytest.approx(fixture["expectedTaxAmount"])

        if "expectedTotal" in fixture:
            result = TaxCalculator.total_with_combined_taxes(
                fixture["subtotal"],
                *fixture["taxRates"]
            )

            assert result == pytest.approx(fixture["expectedTotal"])

def test_packaging_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["packaging"]:
        result = PackageCalculator.calculate_breakdown_result(
            fixture["totalGrams"],
            fixture["gramsPerUnit"]
        )

        assert result.full_units == fixture["expectedFullUnits"]
        assert result.remaining_grams == pytest.approx(
            fixture["expectedRemainingGrams"]
        )

def test_composite_fixtures_match_expected_values():
    fixtures = load_fixtures()

    for fixture in fixtures["composites"]:
        result = CannabisValueCalculator.price_per_mg_from_weight_and_potency(
            fixture["price"],
            fixture["weightGrams"],
            fixture["potencyPercent"]
        )

        assert result == pytest.approx(fixture["expectedPricePerMg"])