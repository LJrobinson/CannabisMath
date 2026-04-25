export class PriceCalculator {
  static pricePerGram(price: number, grams: number): number {
    this.validateNonNegative(price, "price");
    this.validatePositive(grams, "grams");

    return price / grams;
  }

  static pricePerMg(price: number, totalMg: number): number {
    this.validateNonNegative(price, "price");
    this.validatePositive(totalMg, "totalMg");

    return price / totalMg;
  }

  static discountedPrice(price: number, percentOff: number): number {
    this.validateNonNegative(price, "price");
    this.validatePercent(percentOff, "percentOff");

    return price * (1 - percentOff / 100);
  }

  static savingsAmount(price: number, percentOff: number): number {
    this.validateNonNegative(price, "price");
    this.validatePercent(percentOff, "percentOff");

    return price * (percentOff / 100);
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

  private static validatePercent(value: number, name: string): void {
    if (value < 0 || value > 100) {
      throw new Error(`${name} must be between 0 and 100`);
    }
  }
}