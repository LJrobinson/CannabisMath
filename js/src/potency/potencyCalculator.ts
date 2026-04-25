export class PotencyCalculator {
  private static readonly CONVERSION_FACTOR = 0.877;

  static calculateTotalThc(thc: number, thca: number): number {
    this.validateNonNegative(thc, "thc");
    this.validateNonNegative(thca, "thca");

    return thc + thca * this.CONVERSION_FACTOR;
  }

  static calculateTotalCbd(cbd: number, cbda: number): number {
    this.validateNonNegative(cbd, "cbd");
    this.validateNonNegative(cbda, "cbda");

    return cbd + cbda * this.CONVERSION_FACTOR;
  }

  private static validateNonNegative(value: number, name: string) {
    if (value < 0) {
      throw new Error(`${name} cannot be negative`);
    }
  }
}