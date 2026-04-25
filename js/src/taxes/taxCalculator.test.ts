import { describe, it, expect } from "vitest";
import { TaxCalculator } from "./taxCalculator";

describe("TaxCalculator", () => {
  it("calculates tax amount", () => {
    expect(TaxCalculator.taxAmount(100, 8.375)).toBeCloseTo(8.375);
  });

  it("calculates total with tax", () => {
    expect(TaxCalculator.totalWithTax(100, 10)).toBe(110);
  });

  it("calculates total with combined taxes", () => {
    expect(TaxCalculator.totalWithCombinedTaxes(100, 10, 8.375)).toBeCloseTo(118.375);
  });

  it("calculates combined tax rate", () => {
    expect(TaxCalculator.combinedTaxRate(10, 8.375, 1)).toBeCloseTo(19.375);
  });

  it("calculates tax amount from decimal rate", () => {
    expect(TaxCalculator.taxAmountFromRate(100, 0.08375)).toBeCloseTo(8.375);
  });

  it("calculates total with decimal tax rate", () => {
    expect(TaxCalculator.totalWithTaxRate(100, 0.08375)).toBeCloseTo(108.375);
  });

  it("calculates tax result breakdown", () => {
    const result = TaxCalculator.calculateTaxResult(100, 8.375);

    expect(result.subtotal).toBe(100);
    expect(result.taxRatePercent).toBe(8.375);
    expect(result.taxAmount).toBeCloseTo(8.375);
    expect(result.total).toBeCloseTo(108.375);
  });

  it("throws on negative subtotal", () => {
    expect(() => TaxCalculator.taxAmount(-100, 10)).toThrow();
  });

  it("throws on negative tax rate", () => {
    expect(() => TaxCalculator.taxAmount(100, -5)).toThrow();
  });

  it("throws on percent over one hundred", () => {
    expect(() => TaxCalculator.taxAmount(100, 101)).toThrow();
  });

  it("throws on combined tax percent over one hundred", () => {
    expect(() => TaxCalculator.combinedTaxRate(10, 101)).toThrow();
  });

  it("throws on decimal rate over one", () => {
    expect(() => TaxCalculator.taxAmountFromRate(100, 1.1)).toThrow();
  });
});
