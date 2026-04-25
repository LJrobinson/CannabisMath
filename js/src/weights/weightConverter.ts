export class WeightConverter {
  static readonly GRAMS_PER_RETAIL_EIGHTH = 3.5;
  static readonly GRAMS_PER_RETAIL_QUARTER = 7;
  static readonly GRAMS_PER_RETAIL_HALF_OUNCE = 14;
  static readonly GRAMS_PER_RETAIL_OUNCE = 28;

  static readonly GRAMS_PER_EXACT_OUNCE = 28.349523125;
  static readonly GRAMS_PER_EXACT_POUND = 453.59237;

  static gramsToRetailEighths(grams: number): number {
    this.validateNonNegative(grams, "grams");
    return grams / this.GRAMS_PER_RETAIL_EIGHTH;
  }

  static retailEighthsToGrams(eighths: number): number {
    this.validateNonNegative(eighths, "eighths");
    return eighths * this.GRAMS_PER_RETAIL_EIGHTH;
  }

  static gramsToRetailOunces(grams: number): number {
    this.validateNonNegative(grams, "grams");
    return grams / this.GRAMS_PER_RETAIL_OUNCE;
  }

  static retailOuncesToGrams(ounces: number): number {
    this.validateNonNegative(ounces, "ounces");
    return ounces * this.GRAMS_PER_RETAIL_OUNCE;
  }

  static gramsToExactOunces(grams: number): number {
    this.validateNonNegative(grams, "grams");
    return grams / this.GRAMS_PER_EXACT_OUNCE;
  }

  static exactOuncesToGrams(ounces: number): number {
    this.validateNonNegative(ounces, "ounces");
    return ounces * this.GRAMS_PER_EXACT_OUNCE;
  }

  static gramsToExactPounds(grams: number): number {
    this.validateNonNegative(grams, "grams");
    return grams / this.GRAMS_PER_EXACT_POUND;
  }

  static exactPoundsToGrams(pounds: number): number {
    this.validateNonNegative(pounds, "pounds");
    return pounds * this.GRAMS_PER_EXACT_POUND;
  }

  private static validateNonNegative(value: number, name: string): void {
    if (value < 0) {
      throw new Error(`${name} cannot be negative`);
    }
  }
}