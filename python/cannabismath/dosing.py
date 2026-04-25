class DoseCalculator:
    @staticmethod
    def total_mg_from_percent(weight_grams: float, potency_percent: float) -> float:
        DoseCalculator._validate_non_negative(weight_grams, "weight_grams")
        DoseCalculator._validate_non_negative(potency_percent, "potency_percent")

        return weight_grams * potency_percent * 10

    @staticmethod
    def dab_mg(potency_percent: float, dab_size_grams: float) -> float:
        DoseCalculator._validate_non_negative(potency_percent, "potency_percent")
        DoseCalculator._validate_non_negative(dab_size_grams, "dab_size_grams")

        return dab_size_grams * potency_percent * 10

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")