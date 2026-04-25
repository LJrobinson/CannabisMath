import type { TaxResult } from "./taxResult";

export class TaxCalculator {
  static taxAmount(subtotal: number, taxRatePercent: number): number {
    this.validateNonNegative(subtotal, "subtotal");
    this.validateNonNegative(taxRatePercent, "taxRatePercent");

    return subtotal * (taxRatePercent / 100);
  }

  static totalWithTax(subtotal: number, taxRatePercent: number): number {
    return subtotal + this.taxAmount(subtotal, taxRatePercent);
  }

  static totalWithCombinedTaxes(subtotal: number, ...taxRates: number[]): number {
    this.validateNonNegative(subtotal, "subtotal");

    const totalRate = taxRates.reduce((sum, rate) => {
      this.validateNonNegative(rate, "taxRate");
      return sum + rate;
    }, 0);

    return subtotal * (1 + totalRate / 100);
  }

  static calculateTaxResult(
    subtotal: number,
    taxRatePercent: number
  ): TaxResult {
    const taxAmount = this.taxAmount(subtotal, taxRatePercent);
    const total = subtotal + taxAmount;

    return {
      subtotal,
      taxRatePercent,
      taxAmount,
      total,
    };
  }

  private static validateNonNegative(value: number, name: string): void {
    if (value < 0) {
      throw new Error(`${name} cannot be negative`);
    }
  }
}