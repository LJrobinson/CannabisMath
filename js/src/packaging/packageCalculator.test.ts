import { describe, it, expect } from "vitest";
import { PackageCalculator } from "./packageCalculator";

describe("PackageCalculator", () => {
  it("calculates full units", () => {
    expect(PackageCalculator.fullUnits(28, 3.5)).toBe(8);
  });

  it("calculates remaining grams", () => {
    expect(PackageCalculator.remainingGrams(453.59237, 3.5)).toBeCloseTo(2.09237);
  });

  it("calculates tuple-style breakdown", () => {
    const result = PackageCalculator.breakdown(28, 3.5);

    expect(result.fullUnits).toBe(8);
    expect(result.remainingGrams).toBe(0);
  });

  it("calculates full breakdown", () => {
    const result = PackageCalculator.calculateBreakdownResult(453.59237, 3.5);

    expect(result.totalGrams).toBe(453.59237);
    expect(result.gramsPerUnit).toBe(3.5);
    expect(result.fullUnits).toBe(129);
    expect(result.remainingGrams).toBeCloseTo(2.09237);
  });

  it("throws on negative grams", () => {
    expect(() => PackageCalculator.fullUnits(-1, 3.5)).toThrow();
  });

  it("allows zero total grams", () => {
    expect(PackageCalculator.fullUnits(0, 3.5)).toBe(0);
    expect(PackageCalculator.remainingGrams(0, 3.5)).toBe(0);
  });

  it("throws on zero grams per unit", () => {
    expect(() => PackageCalculator.fullUnits(28, 0)).toThrow();
  });
});
