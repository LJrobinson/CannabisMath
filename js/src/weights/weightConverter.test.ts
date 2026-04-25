import { describe, it, expect } from "vitest";
import { WeightConverter } from "./weightConverter";

describe("WeightConverter", () => {
  it("converts grams to retail eighths", () => {
    expect(WeightConverter.gramsToRetailEighths(28)).toBe(8);
  });

  it("converts retail eighths to grams", () => {
    expect(WeightConverter.retailEighthsToGrams(8)).toBe(28);
  });

  it("converts grams to retail ounces", () => {
    expect(WeightConverter.gramsToRetailOunces(28)).toBe(1);
  });

  it("converts retail ounces to grams", () => {
    expect(WeightConverter.retailOuncesToGrams(1)).toBe(28);
  });

  it("converts exact pounds to grams", () => {
    expect(WeightConverter.exactPoundsToGrams(1)).toBe(453.59237);
  });

  it("converts grams to exact pounds", () => {
    expect(WeightConverter.gramsToExactPounds(453.59237)).toBe(1);
  });

  it("throws on negative weight", () => {
    expect(() => WeightConverter.gramsToRetailEighths(-1)).toThrow();
  });
});