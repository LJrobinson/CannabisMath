import pytest

from cannabismath import DoseCalculator


def test_mg_per_serving_valid_input_returns_correct_value():
    assert DoseCalculator.mg_per_serving(100, 10) == 10


def test_total_mg_from_percent_one_gram_at_twenty_five_percent_returns_250_mg():
    assert DoseCalculator.total_mg_from_percent(1, 25) == 250


def test_mg_per_gram_twenty_five_percent_returns_250_mg():
    assert DoseCalculator.mg_per_gram(25) == 250


def test_dab_mg_point_zero_five_gram_at_eighty_percent_returns_40_mg():
    assert DoseCalculator.dab_mg(80, 0.05) == pytest.approx(40)


def test_mg_per_serving_zero_servings_throws_exception():
    with pytest.raises(ValueError):
        DoseCalculator.mg_per_serving(100, 0)


def test_negative_weight_throws_exception():
    with pytest.raises(ValueError):
        DoseCalculator.total_mg_from_percent(-1, 25)


def test_negative_potency_throws_exception():
    with pytest.raises(ValueError):
        DoseCalculator.mg_per_gram(-25)
