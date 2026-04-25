class TaxCalculator:
    @staticmethod
    def tax_amount(subtotal: float, tax_rate_percent: float) -> float:
        TaxCalculator._validate_non_negative(subtotal, "subtotal")
        TaxCalculator._validate_non_negative(tax_rate_percent, "tax_rate_percent")

        return subtotal * (tax_rate_percent / 100)

    @staticmethod
    def total_with_tax(subtotal: float, tax_rate_percent: float) -> float:
        return subtotal + TaxCalculator.tax_amount(subtotal, tax_rate_percent)

    @staticmethod
    def total_with_combined_taxes(subtotal: float, *tax_rates: float) -> float:
        TaxCalculator._validate_non_negative(subtotal, "subtotal")

        total = subtotal

        for rate in tax_rates:
            TaxCalculator._validate_non_negative(rate, "tax_rate")
            total += subtotal * (rate / 100)

        return total

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")