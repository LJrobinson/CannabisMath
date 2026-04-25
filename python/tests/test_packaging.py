import pytest

from cannabismath import PackageCalculator


def test_full_units_pound_to_eighths_returns_correct_count():
    assert PackageCalculator.full_units(453.59237, 3.5) == 129


def test_remaining_grams_pound_to_eighths_returns_correct_remainder():
    assert PackageCalculator.remaining_grams(453.59237, 3.5) == pytest.approx(
        2.09237
    )


def test_breakdown_returns_units_and_remainder():
    full_units, remaining_grams = PackageCalculator.breakdown(28, 3.5)

    assert full_units == 8
    assert remaining_grams == 0


def test_calculate_breakdown_result_returns_full_breakdown():
    result = PackageCalculator.calculate_breakdown_result(453.59237, 3.5)

    assert result.total_grams == 453.59237
    assert result.grams_per_unit == 3.5
    assert result.full_units == 129
    assert result.remaining_grams == pytest.approx(2.09237)


def test_exact_division_no_remainder():
    assert PackageCalculator.remaining_grams(14, 7) == 0


def test_zero_total_grams_allowed():
    assert PackageCalculator.full_units(0, 3.5) == 0
    assert PackageCalculator.remaining_grams(0, 3.5) == 0


def test_negative_input_throws_exception():
    with pytest.raises(ValueError):
        PackageCalculator.full_units(-1, 3.5)


def test_zero_unit_size_throws_exception():
    with pytest.raises(ValueError):
        PackageCalculator.full_units(28, 0)
