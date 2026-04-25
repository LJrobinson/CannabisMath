from dataclasses import dataclass


@dataclass(frozen=True)
class PricingResult:
    price: float
    quantity: float
    unit_price: float
    unit_label: str


class PriceCalculator:
    @staticmethod
    def price_per_gram(price: float, grams: float) -> float:
        PriceCalculator._validate_positive(grams, "grams")
        PriceCalculator._validate_non_negative(price, "price")

        return price / grams

    @staticmethod
    def price_per_mg(price: float, total_mg: float) -> float:
        PriceCalculator._validate_positive(total_mg, "total_mg")
        PriceCalculator._validate_non_negative(price, "price")

        return price / total_mg

    @staticmethod
    def discounted_price(price: float, discount_percent: float) -> float:
        PriceCalculator._validate_non_negative(price, "price")
        PriceCalculator._validate_percent(discount_percent, "discount_percent")

        return price * (1 - (discount_percent / 100))

    @staticmethod
    def savings_amount(price: float, discount_percent: float) -> float:
        PriceCalculator._validate_non_negative(price, "price")
        PriceCalculator._validate_percent(discount_percent, "discount_percent")

        return price - PriceCalculator.discounted_price(price, discount_percent)

    @staticmethod
    def calculate_price_per_gram_result(price: float, grams: float) -> PricingResult:
        unit_price = PriceCalculator.price_per_gram(price, grams)

        return PricingResult(
            price=price,
            quantity=grams,
            unit_price=unit_price,
            unit_label="gram"
        )

    @staticmethod
    def calculate_price_per_mg_result(price: float, total_mg: float) -> PricingResult:
        unit_price = PriceCalculator.price_per_mg(price, total_mg)

        return PricingResult(
            price=price,
            quantity=total_mg,
            unit_price=unit_price,
            unit_label="mg"
        )

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")

    @staticmethod
    def _validate_positive(value: float, name: str) -> None:
        if value <= 0:
            raise ValueError(f"{name} must be greater than zero")

    @staticmethod
    def _validate_percent(value: float, name: str) -> None:
        if value < 0 or value > 100:
            raise ValueError(f"{name} must be between 0 and 100")
