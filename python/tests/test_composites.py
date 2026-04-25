import pytest

from cannabismath import CannabisValueCalculator


def test_total_mg_from_weight_and_potency_returns_correct_value():
    assert CannabisValueCalculator.total_mg_from_weight_and_potency(3.5, 20) == 700


def test_price_per_mg_from_weight_and_potency_returns_correct_value():
    result = CannabisValueCalculator.price_per_mg_from_weight_and_potency(
        price=35,
        weight_grams=3.5,
        potency_percent=20
    )

    assert result == pytest.approx(0.05)


def test_price_per_gram_after_discount_returns_correct_value():
    result = CannabisValueCalculator.price_per_gram_after_discount(
        price=40,
        grams=3.5,
        discount_percent=12.5
    )

    assert result == pytest.approx(10)


def test_price_per_mg_after_discount_returns_correct_value():
    result = CannabisValueCalculator.price_per_mg_after_discount(
        price=40,
        weight_grams=3.5,
        potency_percent=20,
        discount_percent=12.5
    )

    assert result == pytest.approx(0.05)


def test_price_per_mg_from_weight_and_potency_zero_potency_throws_exception():
    with pytest.raises(ValueError):
        CannabisValueCalculator.price_per_mg_from_weight_and_potency(
            price=35,
            weight_grams=3.5,
            potency_percent=0
        )
