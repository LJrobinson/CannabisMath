class PotencyCalculator:
    CONVERSION_FACTOR = 0.877

    @staticmethod
    def calculate_total_thc(thc, thca):
        PotencyCalculator._validate_non_negative(thc, "thc")
        PotencyCalculator._validate_non_negative(thca, "thca")
        return thc + thca * PotencyCalculator.CONVERSION_FACTOR

    @staticmethod
    def calculate_total_cbd(cbd, cbda):
        PotencyCalculator._validate_non_negative(cbd, "cbd")
        PotencyCalculator._validate_non_negative(cbda, "cbda")
        return cbd + cbda * PotencyCalculator.CONVERSION_FACTOR

    @staticmethod
    def _validate_non_negative(value, name):
        if value < 0:
            raise ValueError(f"{name} cannot be negative")