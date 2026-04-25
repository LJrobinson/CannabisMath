import { describe, it, expect } from "vitest";
import { PriceCalculator } from "./priceCalculator";

describe("PriceCalculator", () => {
  it("calculates price per gram", () => {
    expect(PriceCalculator.pricePerGram(35, 3.5)).toBe(10);
  });

  it("calculates price per mg", () => {
    expect(PriceCalculator.pricePerMg(25, 500)).toBe(0.05);
  });

  it("calculates discounted price", () => {
    expect(PriceCalculator.discountedPrice(100, 20)).toBe(80);
  });

  it("calculates savings amount", () => {
    expect(PriceCalculator.savingsAmount(100, 20)).toBe(20);
  });

  it("calculates one hundred percent off as zero", () => {
    expect(PriceCalculator.discountedPrice(100, 100)).toBe(0);
  });

  it("returns price per gram result breakdown", () => {
    const result = PriceCalculator.calculatePricePerGramResult(35, 3.5);

    expect(result.price).toBe(35);
    expect(result.quantity).toBe(3.5);
    expect(result.unitPrice).toBe(10);
    expect(result.unitLabel).toBe("gram");
  });

  it("returns price per mg result breakdown", () => {
    const result = PriceCalculator.calculatePricePerMgResult(25, 500);

    expect(result.price).toBe(25);
    expect(result.quantity).toBe(500);
    expect(result.unitPrice).toBe(0.05);
    expect(result.unitLabel).toBe("mg");
  });

  it("throws on zero grams", () => {
    expect(() => PriceCalculator.pricePerGram(35, 0)).toThrow();
  });

  it("throws on zero mg", () => {
    expect(() => PriceCalculator.pricePerMg(25, 0)).toThrow();
  });

  it("throws on percent over one hundred", () => {
    expect(() => PriceCalculator.discountedPrice(100, 101)).toThrow();
  });
});
