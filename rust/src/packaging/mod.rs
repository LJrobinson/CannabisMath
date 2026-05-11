#[derive(Debug, PartialEq)]
pub struct PackagingBreakdown {
    pub full_units: u64,
    pub remaining_grams: f64,
}

pub fn packaging_breakdown(total_grams: f64, grams_per_unit: f64) -> PackagingBreakdown {
    let full_units = (total_grams / grams_per_unit).floor() as u64;
    let remaining_grams = total_grams - (full_units as f64 * grams_per_unit);

    PackagingBreakdown {
        full_units,
        remaining_grams,
    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_pound_to_eighths_breakdown() {
        let result = packaging_breakdown(453.59237, 3.5);

        assert_eq!(result.full_units, 129);
        assert!((result.remaining_grams - 2.09237).abs() < 0.0001);
    }

    #[test]
    fn calculates_exact_eighth_breakdown() {
        let result = packaging_breakdown(28.0, 3.5);

        assert_eq!(result.full_units, 8);
        assert!((result.remaining_grams - 0.0).abs() < 0.0001);
    }

    #[test]
    fn calculates_less_than_one_unit_breakdown() {
        let result = packaging_breakdown(2.0, 3.5);

        assert_eq!(result.full_units, 0);
        assert!((result.remaining_grams - 2.0).abs() < 0.0001);
    }
}