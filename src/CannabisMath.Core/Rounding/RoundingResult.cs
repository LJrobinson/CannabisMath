namespace CannabisMath.Core.Rounding;

public sealed record RoundingResult(
    decimal OriginalValue,
    decimal RoundedValue,
    decimal Difference,
    RoundingMode Mode,
    decimal Increment
);