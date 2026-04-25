import { describe, it, expect } from "vitest";
import { PotencyCalculator } from "./potencyCalculator";

describe("PotencyCalculator", () => {
  it("calculates total THC correctly", () => {
    const result = PotencyCalculator.calculateTotalThc(1.2, 24.8);

    expect(result).toBeCloseTo(22.9496);
  });

  it("calculates total CBD correctly", () => {
    const result = PotencyCalculator.calculateTotalCbd(0.5, 10);

    expect(result).toBeCloseTo(9.27);
  });

  it("throws on negative input", () => {
    expect(() =>
      PotencyCalculator.calculateTotalThc(-1, 10)
    ).toThrow();
  });
});