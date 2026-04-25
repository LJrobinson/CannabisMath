from dataclasses import dataclass
from enum import Enum


class RoundingMode(Enum):
    NEAREST = "Nearest"
    UP = "Up"
    DOWN = "Down"
    AWAY_FROM_ZERO = "AwayFromZero"
    TO_ZERO = "ToZero"


@dataclass(frozen=True)
class RoundingResult:
    original_value: float
    rounded_value: float
    difference: float
    mode: RoundingMode
    increment: float


class RoundingCalculator:
    @staticmethod
    def round_currency(value: float) -> float:
        return RoundingCalculator._round_away_from_zero_decimal_places(value, 2)

    @staticmethod
    def round_weight(value: float) -> float:
        return RoundingCalculator._round_away_from_zero_decimal_places(value, 3)

    @staticmethod
    def round_milligrams(value: float) -> float:
        return RoundingCalculator._round_away_from_zero_decimal_places(value, 2)

    @staticmethod
    def round_percent(value: float) -> float:
        return RoundingCalculator._round_away_from_zero_decimal_places(value, 2)

    @staticmethod
    def round_to_increment(value: float, increment: float, mode: RoundingMode) -> float:
        RoundingCalculator._validate_positive(increment, "increment")

        quotient = value / increment

        if mode == RoundingMode.NEAREST:
            rounded_quotient = RoundingCalculator._round_away_from_zero_whole(quotient)
        elif mode == RoundingMode.UP:
            rounded_quotient = RoundingCalculator._ceil(quotient)
        elif mode == RoundingMode.DOWN:
            rounded_quotient = RoundingCalculator._floor(quotient)
        elif mode == RoundingMode.AWAY_FROM_ZERO:
            rounded_quotient = (
                RoundingCalculator._ceil(quotient)
                if quotient >= 0
                else RoundingCalculator._floor(quotient)
            )
        elif mode == RoundingMode.TO_ZERO:
            rounded_quotient = (
                RoundingCalculator._floor(quotient)
                if quotient >= 0
                else RoundingCalculator._ceil(quotient)
            )
        else:
            raise ValueError(f"Unsupported rounding mode: {mode}")

        return RoundingCalculator._round_away_from_zero_decimal_places(
            rounded_quotient * increment,
            10
        )

    @staticmethod
    def round_cash_to_nearest_nickel(value: float) -> float:
        return RoundingCalculator.round_to_increment(value, 0.05, RoundingMode.NEAREST)

    @staticmethod
    def round_cash_up_to_nickel(value: float) -> float:
        return RoundingCalculator.round_to_increment(value, 0.05, RoundingMode.UP)

    @staticmethod
    def round_cash_down_to_nickel(value: float) -> float:
        return RoundingCalculator.round_to_increment(value, 0.05, RoundingMode.DOWN)

    @staticmethod
    def rounding_difference(original_value: float, rounded_value: float) -> float:
        return RoundingCalculator._round_away_from_zero_decimal_places(
            rounded_value - original_value,
            10
        )

    @staticmethod
    def round_with_result(
        value: float,
        increment: float,
        mode: RoundingMode
    ) -> RoundingResult:
        rounded = RoundingCalculator.round_to_increment(value, increment, mode)
        difference = RoundingCalculator.rounding_difference(value, rounded)

        return RoundingResult(
            original_value=value,
            rounded_value=rounded,
            difference=difference,
            mode=mode,
            increment=increment
        )

    @staticmethod
    def _round_away_from_zero_whole(value: float) -> int:
        import math

        return int(math.copysign(math.floor(abs(value) + 0.5), value))

    @staticmethod
    def _round_away_from_zero_decimal_places(value: float, decimal_places: int) -> float:
        factor = 10 ** decimal_places
        return RoundingCalculator._round_away_from_zero_whole(value * factor) / factor

    @staticmethod
    def _ceil(value: float) -> int:
        import math

        return math.ceil(value)

    @staticmethod
    def _floor(value: float) -> int:
        import math

        return math.floor(value)

    @staticmethod
    def _validate_positive(value: float, name: str) -> None:
        if value <= 0:
            raise ValueError(f"{name} must be greater than zero")