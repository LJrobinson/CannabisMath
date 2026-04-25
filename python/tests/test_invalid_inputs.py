import pytest

from cannabismath import (
    CannabisValueCalculator,
    DoseCalculator,
    PackageCalculator,
    PotencyCalculator,
    PriceCalculator,
    RoundingCalculator,
    RoundingMode,
    TaxCalculator,
    WeightConverter,
)


def test_potency_rejects_negative_values():
    with pytest.raises(ValueError):
        PotencyCalculator.calculate_total_thc(-1, 10)


def test_weight_rejects_negative_values():
    with pytest.raises(ValueError):
        WeightConverter.grams_to_retail_eighths(-1)


def test_dosing_rejects_negative_weight():
    with pytest.raises(ValueError):
        DoseCalculator.total_mg_from_percent(-1, 20)


def test_pricing_rejects_zero_grams():
    with pytest.raises(ValueError):
        PriceCalculator.price_per_gram(35, 0)


def test_rounding_rejects_zero_increment():
    with pytest.raises(ValueError):
        RoundingCalculator.round_to_increment(10, 0, RoundingMode.NEAREST)


def test_taxes_reject_negative_subtotal():
    with pytest.raises(ValueError):
        TaxCalculator.tax_amount(-100, 8.375)


def test_packaging_rejects_zero_unit_size():
    with pytest.raises(ValueError):
        PackageCalculator.calculate_breakdown_result(28, 0)


def test_composites_reject_zero_potency_via_price_per_mg():
    with pytest.raises(ValueError):
        CannabisValueCalculator.price_per_mg_from_weight_and_potency(
            35,
            3.5,
            0,
        )