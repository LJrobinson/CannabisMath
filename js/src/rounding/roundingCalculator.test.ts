import { describe, it, expect } from "vitest";
import { RoundingCalculator } from "./roundingCalculator";
import { RoundingMode } from "./roundingMode";

describe("RoundingCalculator", () => {
  it("rounds currency to two decimals", () => {
    expect(RoundingCalculator.roundCurrency(10.125)).toBe(10.13);
  });

  it("rounds weight to three decimals", () => {
    expect(RoundingCalculator.roundWeight(3.4567)).toBe(3.457);
  });

  it("rounds milligrams to two decimals", () => {
    expect(RoundingCalculator.roundMilligrams(125.555)).toBe(125.56);
  });

  it("rounds percent to two decimals", () => {
    expect(RoundingCalculator.roundPercent(23.456)).toBe(23.46);
  });

  it.each([
    [10.0, 10.0],
    [10.01, 10.0],
    [10.02, 10.0],
    [10.03, 10.05],
    [10.04, 10.05],
    [10.05, 10.05],
    [10.06, 10.05],
    [10.07, 10.05],
    [10.08, 10.1],
    [10.09, 10.1],
  ])("rounds cash to nearest nickel: %s -> %s", (input, expected) => {
    expect(RoundingCalculator.roundCashToNearestNickel(input)).toBeCloseTo(
      expected
    );
  });

  it("rounds cash up to nickel", () => {
    expect(RoundingCalculator.roundCashUpToNickel(10.01)).toBe(10.05);
  });

  it("rounds cash down to nickel", () => {
    expect(RoundingCalculator.roundCashDownToNickel(10.09)).toBe(10.05);
  });

  it("rounds to nearest quarter increment", () => {
    expect(
      RoundingCalculator.roundToIncrement(10.13, 0.25, RoundingMode.Nearest)
    ).toBe(10.25);
  });

  it("rounds whole dollar down", () => {
    expect(RoundingCalculator.roundToIncrement(10.99, 1, RoundingMode.Down)).toBe(
      10
    );
  });

  it("rounds whole dollar up", () => {
    expect(RoundingCalculator.roundToIncrement(10.01, 1, RoundingMode.Up)).toBe(
      11
    );
  });

  it("calculates rounding difference", () => {
    expect(RoundingCalculator.roundingDifference(10.03, 10.05)).toBeCloseTo(
      0.02
    );
  });

  it("returns full rounding result", () => {
    const result = RoundingCalculator.roundWithResult(
      10.03,
      0.05,
      RoundingMode.Nearest
    );

    expect(result.originalValue).toBe(10.03);
    expect(result.roundedValue).toBe(10.05);
    expect(result.difference).toBeCloseTo(0.02);
    expect(result.mode).toBe(RoundingMode.Nearest);
    expect(result.increment).toBe(0.05);
  });

  it("returns negative difference when rounding down", () => {
    const result = RoundingCalculator.roundWithResult(
      10.09,
      0.05,
      RoundingMode.Down
    );

    expect(result.roundedValue).toBe(10.05);
    expect(result.difference).toBeCloseTo(-0.04);
  });

  it("returns zero difference for exact rounded value", () => {
    const result = RoundingCalculator.roundWithResult(
      10.05,
      0.05,
      RoundingMode.Nearest
    );

    expect(result.difference).toBe(0);
  });

  it("throws on zero increment", () => {
    expect(() =>
      RoundingCalculator.roundToIncrement(10, 0, RoundingMode.Nearest)
    ).toThrow();
  });

  it("throws on negative increment", () => {
    expect(() =>
      RoundingCalculator.roundToIncrement(10, -0.05, RoundingMode.Nearest)
    ).toThrow();
  });
});