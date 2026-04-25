namespace CannabisMath.Core.Pricing;

public sealed record PricingResult(
    decimal Price,
    decimal Quantity,
    decimal UnitPrice,
    string UnitLabel
);