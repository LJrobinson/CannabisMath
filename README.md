## What is CannabisMath?

CannabisMath is a multi-language cannabis calculation library covering:

- COA potency math
- Weight conversions
- Dosing calculations
- Pricing analysis
- Packaging conversions
- Tax calculations

Examples:
var totalThc = PotencyCalculator.CalculateTotalThc(1.2m, 24.8m);

var mg = DoseCalculator.TotalMgFromPercent(3.5m, 20m);

var pricePerMg = CannabisValueCalculator.PricePerMgFromWeightAndPotency(35m, 3.5m, 20m);
