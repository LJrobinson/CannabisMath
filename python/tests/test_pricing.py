import pytest

from cannabismath import PriceCalculator


def test_price_per_gram_valid_input_returns_correct_value():
    assert PriceCalculator.price_per_gram(35, 3.5) == 10


def test_price_per_mg_valid_input_returns_correct_value():
    assert PriceCalculator.price_per_mg(25, 500) == 0.05


def test_discounted_price_twenty_percent_off_returns_discounted_price():
    assert PriceCalculator.discounted_price(100, 20) == 80


def test_savings_amount_twenty_percent_off_returns_savings_amount():
    assert PriceCalculator.savings_amount(100, 20) == 20


def test_discounted_price_one_hundred_percent_off_returns_zero():
    assert PriceCalculator.discounted_price(100, 100) == 0


def test_calculate_price_per_gram_result_returns_full_breakdown():
    result = PriceCalculator.calculate_price_per_gram_result(35, 3.5)

    assert result.price == 35
    assert result.quantity == 3.5
    assert result.unit_price == 10
    assert result.unit_label == "gram"


def test_calculate_price_per_mg_result_returns_full_breakdown():
    result = PriceCalculator.calculate_price_per_mg_result(25, 500)

    assert result.price == 25
    assert result.quantity == 500
    assert result.unit_price == 0.05
    assert result.unit_label == "mg"


def test_price_per_gram_zero_grams_throws_exception():
    with pytest.raises(ValueError):
        PriceCalculator.price_per_gram(35, 0)


def test_price_per_mg_zero_mg_throws_exception():
    with pytest.raises(ValueError):
        PriceCalculator.price_per_mg(25, 0)


def test_discounted_price_over_one_hundred_percent_throws_exception():
    with pytest.raises(ValueError):
        PriceCalculator.discounted_price(100, 101)
