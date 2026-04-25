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
        PriceCalculator._validate_non_negative(discount_percent, "discount_percent")

        return price * (1 - (discount_percent / 100))

    @staticmethod
    def savings_amount(price: float, discount_percent: float) -> float:
        PriceCalculator._validate_non_negative(price, "price")
        PriceCalculator._validate_non_negative(discount_percent, "discount_percent")

        return price - PriceCalculator.discounted_price(price, discount_percent)

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")

    @staticmethod
    def _validate_positive(value: float, name: str) -> None:
        if value <= 0:
            raise ValueError(f"{name} must be greater than zero")