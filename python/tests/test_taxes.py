import pytest

from cannabismath import TaxCalculator


def test_tax_amount_ten_percent_returns_correct_tax():
    assert TaxCalculator.tax_amount(100, 10) == 10


def test_total_with_tax_ten_percent_returns_correct_total():
    assert TaxCalculator.total_with_tax(100, 10) == 110


def test_combined_tax_rate_multiple_rates_returns_sum():
    assert TaxCalculator.combined_tax_rate(10, 8.375, 1) == pytest.approx(19.375)


def test_total_with_combined_taxes_multiple_rates_returns_correct_total():
    assert TaxCalculator.total_with_combined_taxes(100, 10, 8.375) == pytest.approx(
        118.375
    )


def test_tax_amount_from_rate_decimal_rate_returns_correct_tax():
    assert TaxCalculator.tax_amount_from_rate(100, 0.08375) == pytest.approx(8.375)


def test_total_with_tax_rate_decimal_rate_returns_correct_total():
    assert TaxCalculator.total_with_tax_rate(100, 0.08375) == pytest.approx(108.375)


def test_calculate_tax_result_returns_full_breakdown():
    result = TaxCalculator.calculate_tax_result(100, 8.375)

    assert result.subtotal == 100
    assert result.tax_rate_percent == 8.375
    assert result.tax_amount == pytest.approx(8.375)
    assert result.total == pytest.approx(108.375)


def test_negative_subtotal_throws_exception():
    with pytest.raises(ValueError):
        TaxCalculator.tax_amount(-1, 10)


def test_percent_over_one_hundred_throws_exception():
    with pytest.raises(ValueError):
        TaxCalculator.tax_amount(100, 101)


def test_decimal_rate_over_one_throws_exception():
    with pytest.raises(ValueError):
        TaxCalculator.tax_amount_from_rate(100, 1.1)
