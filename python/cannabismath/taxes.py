from dataclasses import dataclass


@dataclass(frozen=True)
class TaxResult:
    subtotal: float
    tax_rate_percent: float
    tax_amount: float
    total: float


class TaxCalculator:
    @staticmethod
    def tax_amount(subtotal: float, tax_rate_percent: float) -> float:
        TaxCalculator._validate_non_negative(subtotal, "subtotal")
        TaxCalculator._validate_percent(tax_rate_percent, "tax_rate_percent")

        return subtotal * (tax_rate_percent / 100)

    @staticmethod
    def total_with_tax(subtotal: float, tax_rate_percent: float) -> float:
        return subtotal + TaxCalculator.tax_amount(subtotal, tax_rate_percent)

    @staticmethod
    def combined_tax_rate(*tax_rate_percents: float) -> float:
        total = 0

        for rate in tax_rate_percents:
            TaxCalculator._validate_percent(rate, "tax_rate_percents")
            total += rate

        return total

    @staticmethod
    def total_with_combined_taxes(subtotal: float, *tax_rates: float) -> float:
        TaxCalculator._validate_non_negative(subtotal, "subtotal")

        combined_rate = TaxCalculator.combined_tax_rate(*tax_rates)

        return TaxCalculator.total_with_tax(subtotal, combined_rate)

    @staticmethod
    def tax_amount_from_rate(subtotal: float, tax_rate: float) -> float:
        TaxCalculator._validate_non_negative(subtotal, "subtotal")
        TaxCalculator._validate_rate(tax_rate, "tax_rate")

        return subtotal * tax_rate

    @staticmethod
    def total_with_tax_rate(subtotal: float, tax_rate: float) -> float:
        return subtotal + TaxCalculator.tax_amount_from_rate(subtotal, tax_rate)

    @staticmethod
    def calculate_tax_result(subtotal: float, tax_rate_percent: float) -> TaxResult:
        tax_amount = TaxCalculator.tax_amount(subtotal, tax_rate_percent)
        total = subtotal + tax_amount

        return TaxResult(
            subtotal=subtotal,
            tax_rate_percent=tax_rate_percent,
            tax_amount=tax_amount,
            total=total
        )

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")

    @staticmethod
    def _validate_percent(value: float, name: str) -> None:
        if value < 0 or value > 100:
            raise ValueError(f"{name} must be between 0 and 100")

    @staticmethod
    def _validate_rate(value: float, name: str) -> None:
        if value < 0 or value > 1:
            raise ValueError(f"{name} must be between 0 and 1")
