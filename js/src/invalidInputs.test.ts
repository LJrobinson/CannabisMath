import { describe, expect, it } from "vitest";

import { CannabisValueCalculator } from "./composites/cannabisValueCalculator";
import { DoseCalculator } from "./dosing/doseCalculator";
import { PackageCalculator } from "./packaging/packageCalculator";
import { PotencyCalculator } from "./potency/potencyCalculator";
import { PriceCalculator } from "./pricing/priceCalculator";
import { RoundingCalculator } from "./rounding/roundingCalculator";
import { RoundingMode } from "./rounding/roundingMode";
import { TaxCalculator } from "./taxes/taxCalculator";
import { WeightConverter } from "./weights/weightConverter";

describe("Invalid input handling", () => {
  it("potency rejects negative values", () => {
    expect(() => PotencyCalculator.calculateTotalThc(-1, 10)).toThrow();
  });

  it("weights reject negative values", () => {
    expect(() => WeightConverter.gramsToRetailEighths(-1)).toThrow();
  });

  it("dosing rejects negative weight", () => {
    expect(() => DoseCalculator.totalMgFromPercent(-1, 20)).toThrow();
  });

  it("pricing rejects zero grams", () => {
    expect(() => PriceCalculator.pricePerGram(35, 0)).toThrow();
  });

  it("pricing rejects percent over one hundred", () => {
    expect(() => PriceCalculator.discountedPrice(100, 101)).toThrow();
  });

  it("rounding rejects zero increment", () => {
    expect(() =>
      RoundingCalculator.roundToIncrement(10, 0, RoundingMode.Nearest)
    ).toThrow();
  });

  it("taxes reject negative subtotal", () => {
    expect(() => TaxCalculator.taxAmount(-100, 8.375)).toThrow();
  });

  it("taxes reject percent over one hundred", () => {
    expect(() => TaxCalculator.taxAmount(100, 101)).toThrow();
  });

  it("taxes reject decimal rate over one", () => {
    expect(() => TaxCalculator.taxAmountFromRate(100, 1.1)).toThrow();
  });

  it("packaging rejects zero unit size", () => {
    expect(() => PackageCalculator.calculateBreakdownResult(28, 0)).toThrow();
  });

  it("packaging allows zero total grams", () => {
    expect(PackageCalculator.calculateBreakdownResult(0, 3.5).fullUnits).toBe(0);
  });

  it("composites reject zero potency via price per mg", () => {
    expect(() =>
      CannabisValueCalculator.pricePerMgFromWeightAndPotency(35, 3.5, 0)
    ).toThrow();
  });
});
