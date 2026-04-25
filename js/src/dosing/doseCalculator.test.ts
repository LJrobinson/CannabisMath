import { describe, it, expect } from "vitest";
import { DoseCalculator } from "./doseCalculator";

describe("DoseCalculator", () => {
  it("calculates mg per serving", () => {
    expect(DoseCalculator.mgPerServing(100, 10)).toBe(10);
  });

  it("calculates total mg from one gram at twenty five percent", () => {
    expect(DoseCalculator.totalMgFromPercent(1, 25)).toBe(250);
  });

  it("calculates mg per gram", () => {
    expect(DoseCalculator.mgPerGram(25)).toBe(250);
  });

  it("calculates dab mg", () => {
    expect(DoseCalculator.dabMg(80, 0.05)).toBe(40);
  });

  it("throws on zero servings", () => {
    expect(() => DoseCalculator.mgPerServing(100, 0)).toThrow();
  });

  it("throws on negative weight", () => {
    expect(() => DoseCalculator.totalMgFromPercent(-1, 25)).toThrow();
  });

  it("throws on negative potency", () => {
    expect(() => DoseCalculator.mgPerGram(-25)).toThrow();
  });
});