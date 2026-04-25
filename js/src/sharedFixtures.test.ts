import { describe, it, expect } from "vitest";
import { readFileSync } from "node:fs";
import { resolve } from "node:path";

import { PotencyCalculator } from "./potency/potencyCalculator";
import { WeightConverter } from "./weights/weightConverter";
import { DoseCalculator } from "./dosing/doseCalculator";
import { PriceCalculator } from "./pricing/priceCalculator";
import { RoundingCalculator } from "./rounding/roundingCalculator";
import { TaxCalculator } from "./taxes/taxCalculator";
import { PackageCalculator } from "./packaging/packageCalculator";
import { CannabisValueCalculator } from "./composites/cannabisValueCalculator";

type CoreFixtures = {
  potency: Array<{
    thcPercent?: number;
    thcaPercent?: number;
    expectedTotalThc?: number;
    cbdPercent?: number;
    cbdaPercent?: number;
    expectedTotalCbd?: number;
  }>;
  weights: Array<{
    grams?: number;
    expectedRetailEighths?: number;
    pounds?: number;
    expectedGrams?: number;
  }>;
  dosing: Array<{
    weightGrams?: number;
    potencyPercent: number;
    expectedTotalMg?: number;
    dabSizeGrams?: number;
    expectedMg?: number;
  }>;
  pricing: Array<{
    price: number;
    grams?: number;
    expectedPricePerGram?: number;
    totalMg?: number;
    expectedPricePerMg?: number;
  }>;
  rounding: Array<{
    value?: number;
    expectedRounded?: number;
    originalValue?: number;
    roundedValue?: number;
    expectedDifference?: number;
  }>;
  taxes: Array<{
    subtotal: number;
    taxRatePercent?: number;
    expectedTaxAmount?: number;
    taxRates?: number[];
    expectedTotal?: number;
  }>;
  packaging: Array<{
    totalGrams: number;
    gramsPerUnit: number;
    expectedFullUnits: number;
    expectedRemainingGrams: number;
  }>;
  composites: Array<{
    price: number;
    weightGrams: number;
    potencyPercent: number;
    expectedPricePerMg: number;
  }>;
};

const fixturePath = resolve(__dirname, "../../shared/test-fixtures/core-fixtures.json");
const fixtures = JSON.parse(readFileSync(fixturePath, "utf-8")) as CoreFixtures;

describe("Shared core fixtures", () => {
  it("matches potency fixtures", () => {
    for (const fixture of fixtures.potency) {
      if (fixture.expectedTotalThc !== undefined) {
        expect(
          PotencyCalculator.calculateTotalThc(
            fixture.thcPercent!,
            fixture.thcaPercent!
          )
        ).toBeCloseTo(fixture.expectedTotalThc);
      }

      if (fixture.expectedTotalCbd !== undefined) {
        expect(
          PotencyCalculator.calculateTotalCbd(
            fixture.cbdPercent!,
            fixture.cbdaPercent!
          )
        ).toBeCloseTo(fixture.expectedTotalCbd);
      }
    }
  });

  it("matches weight fixtures", () => {
    for (const fixture of fixtures.weights) {
      if (fixture.expectedRetailEighths !== undefined) {
        expect(
          WeightConverter.gramsToRetailEighths(fixture.grams!)
        ).toBeCloseTo(fixture.expectedRetailEighths);
      }

      if (fixture.expectedGrams !== undefined) {
        expect(
          WeightConverter.exactPoundsToGrams(fixture.pounds!)
        ).toBeCloseTo(fixture.expectedGrams);
      }
    }
  });

  it("matches dosing fixtures", () => {
    for (const fixture of fixtures.dosing) {
      if (fixture.expectedTotalMg !== undefined) {
        expect(
          DoseCalculator.totalMgFromPercent(
            fixture.weightGrams!,
            fixture.potencyPercent
          )
        ).toBeCloseTo(fixture.expectedTotalMg);
      }

      if (fixture.expectedMg !== undefined) {
        expect(
          DoseCalculator.dabMg(
            fixture.potencyPercent,
            fixture.dabSizeGrams!
          )
        ).toBeCloseTo(fixture.expectedMg);
      }
    }
  });

  it("matches pricing fixtures", () => {
    for (const fixture of fixtures.pricing) {
      if (fixture.expectedPricePerGram !== undefined) {
        expect(
          PriceCalculator.pricePerGram(fixture.price, fixture.grams!)
        ).toBeCloseTo(fixture.expectedPricePerGram);
      }

      if (fixture.expectedPricePerMg !== undefined) {
        expect(
          PriceCalculator.pricePerMg(fixture.price, fixture.totalMg!)
        ).toBeCloseTo(fixture.expectedPricePerMg);
      }
    }
  });

  it("matches rounding fixtures", () => {
    for (const fixture of fixtures.rounding) {
      if (fixture.expectedRounded !== undefined) {
        expect(
          RoundingCalculator.roundCashToNearestNickel(fixture.value!)
        ).toBeCloseTo(fixture.expectedRounded);
      }

      if (fixture.expectedDifference !== undefined) {
        expect(
          RoundingCalculator.roundingDifference(
            fixture.originalValue!,
            fixture.roundedValue!
          )
        ).toBeCloseTo(fixture.expectedDifference);
      }
    }
  });

  it("matches tax fixtures", () => {
    for (const fixture of fixtures.taxes) {
      if (fixture.expectedTaxAmount !== undefined) {
        expect(
          TaxCalculator.taxAmount(
            fixture.subtotal,
            fixture.taxRatePercent!
          )
        ).toBeCloseTo(fixture.expectedTaxAmount);
      }

      if (fixture.expectedTotal !== undefined) {
        expect(
          TaxCalculator.totalWithCombinedTaxes(
            fixture.subtotal,
            ...fixture.taxRates!
          )
        ).toBeCloseTo(fixture.expectedTotal);
      }
    }
  });

  it("matches packaging fixtures", () => {
    for (const fixture of fixtures.packaging) {
      const result = PackageCalculator.calculateBreakdownResult(
        fixture.totalGrams,
        fixture.gramsPerUnit
      );

      expect(result.fullUnits).toBe(fixture.expectedFullUnits);
      expect(result.remainingGrams).toBeCloseTo(
        fixture.expectedRemainingGrams
      );
    }
  });

  it("matches composite fixtures", () => {
    for (const fixture of fixtures.composites) {
      expect(
        CannabisValueCalculator.pricePerMgFromWeightAndPotency(
          fixture.price,
          fixture.weightGrams,
          fixture.potencyPercent
        )
      ).toBeCloseTo(fixture.expectedPricePerMg);
    }
  });
});