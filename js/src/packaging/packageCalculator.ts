import type { PackageBreakdownResult } from "./packageBreakdownResult";

export class PackageCalculator {
  static fullUnits(totalGrams: number, gramsPerUnit: number): number {
    this.validateNonNegative(totalGrams, "totalGrams");
    this.validatePositive(gramsPerUnit, "gramsPerUnit");

    return Math.floor(totalGrams / gramsPerUnit);
  }

  static remainingGrams(totalGrams: number, gramsPerUnit: number): number {
    this.validateNonNegative(totalGrams, "totalGrams");
    this.validatePositive(gramsPerUnit, "gramsPerUnit");

    const remainder = totalGrams % gramsPerUnit;
    return this.round(remainder, 10);
  }

  static calculateBreakdownResult(
    totalGrams: number,
    gramsPerUnit: number
  ): PackageBreakdownResult {
    const fullUnits = this.fullUnits(totalGrams, gramsPerUnit);
    const remainingGrams = this.remainingGrams(totalGrams, gramsPerUnit);

    return {
      totalGrams,
      gramsPerUnit,
      fullUnits,
      remainingGrams,
    };
  }

  private static round(value: number, decimals: number): number {
    const factor = 10 ** decimals;
    return Math.round(value * factor) / factor;
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