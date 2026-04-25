namespace CannabisMath.Core.Packaging;

public sealed record PackageBreakdownResult(
    decimal TotalGrams,
    decimal GramsPerUnit,
    int FullUnits,
    decimal RemainingGrams
);