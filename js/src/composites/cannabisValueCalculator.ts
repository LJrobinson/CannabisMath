import { DoseCalculator } from "../dosing/doseCalculator";
import { PriceCalculator } from "../pricing/priceCalculator";

export class CannabisValueCalculator {
  static totalMgFromWeightAndPotency(
    weightGrams: number,
    potencyPercent: number
  ): number {
    return DoseCalculator.totalMgFromPercent(weightGrams, potencyPercent);
  }

  static pricePerMgFromWeightAndPotency(
    price: number,
    weightGrams: number,
    potencyPercent: number
  ): number {
    const totalMg = DoseCalculator.totalMgFromPercent(
      weightGrams,
      potencyPercent
    );

    return PriceCalculator.pricePerMg(price, totalMg);
  }

  static pricePerGramAfterDiscount(
    price: number,
    grams: number,
    percentOff: number
  ): number {
    const discounted = PriceCalculator.discountedPrice(price, percentOff);
    return PriceCalculator.pricePerGram(discounted, grams);
  }

  static pricePerMgAfterDiscount(
    price: number,
    weightGrams: number,
    potencyPercent: number,
    percentOff: number
  ): number {
    const discounted = PriceCalculator.discountedPrice(price, percentOff);
    return this.pricePerMgFromWeightAndPotency(
      discounted,
      weightGrams,
      potencyPercent
    );
  }
}
