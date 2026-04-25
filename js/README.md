# CannabisMath (TypeScript)

TypeScript port of the CannabisMath calculation engine.

Provides deterministic cannabis calculations for:

- Potency
- Dosing
- Weight conversions
- Pricing
- Packaging
- Taxes
- Rounding
- Composite value calculations

---

## Installation (coming soon)

```bash
npm install cannabismath
```

---

## Usage

```ts
import { DoseCalculator } from "./src/dosing/doseCalculator";

const totalMg = DoseCalculator.totalMgFromPercent(3.5, 20);
// 700
```

---

## Testing

```bash
npm test
```

Uses Vitest.

---

## Notes

- Mirrors C# implementation exactly
- Designed for cross-platform consistency
- Floating-point safe patterns used where necessary

---

## License

MIT