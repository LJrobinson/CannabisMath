from dataclasses import dataclass


@dataclass(frozen=True)
class PackageBreakdownResult:
    full_units: int
    remaining_grams: float


class PackageCalculator:
    @staticmethod
    def calculate_breakdown_result(
        total_grams: float,
        grams_per_unit: float
    ) -> PackageBreakdownResult:
        PackageCalculator._validate_positive(total_grams, "total_grams")
        PackageCalculator._validate_positive(grams_per_unit, "grams_per_unit")

        full_units = int(total_grams // grams_per_unit)
        remaining_grams = total_grams - (full_units * grams_per_unit)

        return PackageBreakdownResult(
            full_units=full_units,
            remaining_grams=remaining_grams
        )

    @staticmethod
    def _validate_positive(value: float, name: str) -> None:
        if value <= 0:
            raise ValueError(f"{name} must be greater than zero")