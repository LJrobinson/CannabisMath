import { RoundingMode } from "./roundingMode";
import type { RoundingResult } from "./roundingResult";

export class RoundingCalculator {
  static roundCurrency(value: number): number {
    return this.roundToDecimalPlaces(value, 2);
  }

  static roundWeight(value: number): number {
    return this.roundToDecimalPlaces(value, 3);
  }

  static roundMilligrams(value: number): number {
    return this.roundToDecimalPlaces(value, 2);
  }

  static roundPercent(value: number): number {
    return this.roundToDecimalPlaces(value, 2);
  }

  static roundToIncrement(
    value: number,
    increment: number,
    mode: RoundingMode
  ): number {
    this.validatePositive(increment, "increment");

    const quotient = value / increment;

    let roundedQuotient: number;

    switch (mode) {
      case RoundingMode.Nearest:
        roundedQuotient = this.roundAwayFromZero(quotient);
        break;

      case RoundingMode.Up:
        roundedQuotient = Math.ceil(quotient);
        break;

      case RoundingMode.Down:
        roundedQuotient = Math.floor(quotient);
        break;

      case RoundingMode.AwayFromZero:
        roundedQuotient =
          quotient >= 0 ? Math.ceil(quotient) : Math.floor(quotient);
        break;

      case RoundingMode.ToZero:
        roundedQuotient =
          quotient >= 0 ? Math.floor(quotient) : Math.ceil(quotient);
        break;

      default:
        throw new Error(`Unsupported rounding mode: ${mode}`);
    }

    return this.roundToDecimalPlaces(roundedQuotient * increment, 10);
  }

  static roundCashToNearestNickel(value: number): number {
    return this.roundToIncrement(value, 0.05, RoundingMode.Nearest);
  }

  static roundCashUpToNickel(value: number): number {
    return this.roundToIncrement(value, 0.05, RoundingMode.Up);
  }

  static roundCashDownToNickel(value: number): number {
    return this.roundToIncrement(value, 0.05, RoundingMode.Down);
  }

  static roundingDifference(originalValue: number, roundedValue: number): number {
    return this.roundToDecimalPlaces(roundedValue - originalValue, 10);
  }

  static roundWithResult(
    value: number,
    increment: number,
    mode: RoundingMode
  ): RoundingResult {
    const rounded = this.roundToIncrement(value, increment, mode);
    const difference = this.roundingDifference(value, rounded);

    return {
      originalValue: value,
      roundedValue: rounded,
      difference,
      mode,
      increment,
    };
  }

  private static roundToDecimalPlaces(value: number, decimalPlaces: number): number {
    const factor = 10 ** decimalPlaces;
    return Math.sign(value) * Math.round(Math.abs(value) * factor) / factor;
  }

  private static roundAwayFromZero(value: number): number {
    return Math.sign(value) * Math.round(Math.abs(value));
  }

  private static validatePositive(value: number, name: string): void {
    if (value <= 0) {
      throw new Error(`${name} must be greater than zero`);
    }
  }
}