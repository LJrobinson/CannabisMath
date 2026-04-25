from .dosing import DoseCalculator
from .pricing import PriceCalculator


class CannabisValueCalculator:
    @staticmethod
    def price_per_mg_from_weight_and_potency(
        price: float,
        weight_grams: float,
        potency_percent: float
    ) -> float:
        total_mg = DoseCalculator.total_mg_from_percent(
            weight_grams,
            potency_percent
        )

        return PriceCalculator.price_per_mg(price, total_mg)

    @staticmethod
    def price_per_gram_after_discount(
        price: float,
        grams: float,
        discount_percent: float
    ) -> float:
        discounted_price = PriceCalculator.discounted_price(
            price,
            discount_percent
        )

        return PriceCalculator.price_per_gram(discounted_price, grams)

    @staticmethod
    def price_per_mg_after_discount(
        price: float,
        weight_grams: float,
        potency_percent: float,
        discount_percent: float
    ) -> float:
        discounted_price = PriceCalculator.discounted_price(
            price,
            discount_percent
        )

        total_mg = DoseCalculator.total_mg_from_percent(
            weight_grams,
            potency_percent
        )

        return PriceCalculator.price_per_mg(discounted_price, total_mg)