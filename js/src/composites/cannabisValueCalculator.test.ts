import { describe, it, expect } from "vitest";
import { CannabisValueCalculator } from "./cannabisValueCalculator";

describe("CannabisValueCalculator", () => {
  it("calculates total mg from weight and potency", () => {
    const result =
      CannabisValueCalculator.totalMgFromWeightAndPotency(3.5, 20);

    expect(result).toBe(700);
  });

  it("calculates price per mg from weight and potency", () => {
    const result =
      CannabisValueCalculator.pricePerMgFromWeightAndPotency(
        35,
        3.5,
        20
      );

    expect(result).toBeCloseTo(0.05);
  });

  it("calculates price per gram after discount", () => {
    const result =
      CannabisValueCalculator.pricePerGramAfterDiscount(
        100,
        10,
        20
      );

    expect(result).toBe(8); // 80 / 10
  });

  it("calculates price per mg after discount", () => {
    const result =
      CannabisValueCalculator.pricePerMgAfterDiscount(
        35,
        3.5,
        20,
        20
      );

    expect(result).toBeCloseTo(0.04);
  });
});
