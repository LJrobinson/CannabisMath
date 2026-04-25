import { RoundingMode } from "./roundingMode";

export type RoundingResult = {
  originalValue: number;
  roundedValue: number;
  difference: number;
  mode: RoundingMode;
  increment: number;
};