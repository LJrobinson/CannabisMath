class WeightConverter:
    GRAMS_PER_RETAIL_EIGHTH = 3.5
    GRAMS_PER_RETAIL_QUARTER = 7
    GRAMS_PER_RETAIL_HALF_OUNCE = 14
    GRAMS_PER_RETAIL_OUNCE = 28

    GRAMS_PER_EXACT_OUNCE = 28.349523125
    GRAMS_PER_EXACT_POUND = 453.59237

    @staticmethod
    def grams_to_retail_eighths(grams: float) -> float:
        WeightConverter._validate_non_negative(grams, "grams")
        return grams / WeightConverter.GRAMS_PER_RETAIL_EIGHTH

    @staticmethod
    def retail_eighths_to_grams(eighths: float) -> float:
        WeightConverter._validate_non_negative(eighths, "eighths")
        return eighths * WeightConverter.GRAMS_PER_RETAIL_EIGHTH

    @staticmethod
    def grams_to_retail_ounces(grams: float) -> float:
        WeightConverter._validate_non_negative(grams, "grams")
        return grams / WeightConverter.GRAMS_PER_RETAIL_OUNCE

    @staticmethod
    def retail_ounces_to_grams(ounces: float) -> float:
        WeightConverter._validate_non_negative(ounces, "ounces")
        return ounces * WeightConverter.GRAMS_PER_RETAIL_OUNCE

    @staticmethod
    def grams_to_exact_ounces(grams: float) -> float:
        WeightConverter._validate_non_negative(grams, "grams")
        return grams / WeightConverter.GRAMS_PER_EXACT_OUNCE

    @staticmethod
    def exact_ounces_to_grams(ounces: float) -> float:
        WeightConverter._validate_non_negative(ounces, "ounces")
        return ounces * WeightConverter.GRAMS_PER_EXACT_OUNCE

    @staticmethod
    def grams_to_exact_pounds(grams: float) -> float:
        WeightConverter._validate_non_negative(grams, "grams")
        return grams / WeightConverter.GRAMS_PER_EXACT_POUND

    @staticmethod
    def exact_pounds_to_grams(pounds: float) -> float:
        WeightConverter._validate_non_negative(pounds, "pounds")
        return pounds * WeightConverter.GRAMS_PER_EXACT_POUND

    @staticmethod
    def _validate_non_negative(value: float, name: str) -> None:
        if value < 0:
            raise ValueError(f"{name} cannot be negative")