from dataclasses import dataclass


@dataclass(frozen=True)
class PackageBreakdownResult:
    total_grams: float
    grams_per_unit: float
    full_units: int
    remaining_grams: float


class PackageCalculator:
    @staticmethod
    def full_units(total_grams: float, grams_per_unit: float) -> int:
        PackageCalculator._validate_non_negative(total_grams, "total_grams")
        PackageCalculator._validate_positive(grams_per_unit, "grams_per_unit")

        return int(total_grams // grams_per_unit)

    @staticmethod
    def remaining_grams(total_grams: float, grams_per_unit: float) -> float:
        PackageCalculator._validate_non_negative(total_grams, "total_grams")
        PackageCalculator._validate_positive(grams_per_unit, "grams_per_unit")

        full_units = PackageCalculator.full_units(total_grams, grams_per_unit)
        return total_grams - (full_units * grams_per_unit)

    @staticmethod
    def breakdown(total_grams: float, grams_per_unit: float):
        full_units = PackageCalculator.full_units(total_grams, grams_per_unit)
        remaining_grams = PackageCalculator.remaining_grams(
            total_grams,
            grams_per_unit
        )

        return full_units, remaining_grams

    @staticmethod
    def calculate_breakdown_result(
        total_grams: float,
        grams_per_unit: float
    ) -> PackageBreakdownResult:
        full_units = PackageCalculator.full_units(total_grams, grams_per_unit)
        remaining_grams = PackageCalculator.remaining_grams(
            total_grams,
            grams_per_unit
        )

        return PackageBreakdownResult(
            total_grams=total_grams,
            grams_per_unit=grams_per_unit,
            full_units=full_units,
            remaining_grams=remaining_grams
        )

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")

    @staticmethod
    def _validate_positive(value: float, name: str) -> None:
        if value <= 0:
            raise ValueError(f"{name} must be greater than zero")
