import type { TaxResult } from "./taxResult";

export class TaxCalculator {
  static taxAmount(subtotal: number, taxRatePercent: number): number {
    this.validateNonNegative(subtotal, "subtotal");
    this.validatePercent(taxRatePercent, "taxRatePercent");

    return subtotal * (taxRatePercent / 100);
  }

  static totalWithTax(subtotal: number, taxRatePercent: number): number {
    return subtotal + this.taxAmount(subtotal, taxRatePercent);
  }

  static combinedTaxRate(...taxRatePercents: number[]): number {
    return taxRatePercents.reduce((sum, rate) => {
      this.validatePercent(rate, "taxRatePercents");
      return sum + rate;
    }, 0);
  }

  static totalWithCombinedTaxes(subtotal: number, ...taxRates: number[]): number {
    this.validateNonNegative(subtotal, "subtotal");

    const totalRate = this.combinedTaxRate(...taxRates);

    return subtotal * (1 + totalRate / 100);
  }

  static taxAmountFromRate(subtotal: number, taxRate: number): number {
    this.validateNonNegative(subtotal, "subtotal");
    this.validateRate(taxRate, "taxRate");

    return subtotal * taxRate;
  }

  static totalWithTaxRate(subtotal: number, taxRate: number): number {
    return subtotal + this.taxAmountFromRate(subtotal, taxRate);
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

  private static validatePercent(value: number, name: string): void {
    if (value < 0 || value > 100) {
      throw new Error(`${name} must be between 0 and 100`);
    }
  }

  private static validateRate(value: number, name: string): void {
    if (value < 0 || value > 1) {
      throw new Error(`${name} must be between 0 and 1`);
    }
  }
}
