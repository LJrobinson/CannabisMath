export class DoseCalculator {
  static mgPerServing(totalMg: number, servings: number): number {
    this.validateNonNegative(totalMg, "totalMg");
    this.validatePositive(servings, "servings");

    return totalMg / servings;
  }

  static totalMgFromPercent(weightGrams: number, potencyPercent: number): number {
    this.validateNonNegative(weightGrams, "weightGrams");
    this.validateNonNegative(potencyPercent, "potencyPercent");

    return weightGrams * 1000 * (potencyPercent / 100);
  }

  static mgPerGram(potencyPercent: number): number {
    this.validateNonNegative(potencyPercent, "potencyPercent");

    return 1000 * (potencyPercent / 100);
  }

  static dabMg(potencyPercent: number, dabSizeGrams: number): number {
    this.validateNonNegative(potencyPercent, "potencyPercent");
    this.validateNonNegative(dabSizeGrams, "dabSizeGrams");

    return this.totalMgFromPercent(dabSizeGrams, potencyPercent);
  }

  private static validateNonNegative(value: number, name: string): void {
    if (value < 0) {
      throw new Error(`${name} cannot be negative`);
    }
  }

  private static validatePositive(value: number, name: string): void {
    if (value <= 0) {
      throw new Error(`${name} must be greater than zero`);
    }
  }
}