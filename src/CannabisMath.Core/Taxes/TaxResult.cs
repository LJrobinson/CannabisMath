namespace CannabisMath.Core.Taxes;

public sealed record TaxResult(
    decimal Subtotal,
    decimal TaxRatePercent,
    decimal TaxAmount,
    decimal Total
);