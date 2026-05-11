pub fn tax_amount(subtotal: f64, tax_rate_percent: f64) -> f64 {
    subtotal * (tax_rate_percent / 100.0)
}

pub fn total_with_combined_taxes(subtotal: f64, tax_rates: &[f64]) -> f64 {
    let total_tax_rate: f64 = tax_rates.iter().sum();
    subtotal + tax_amount(subtotal, total_tax_rate)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_tax_amount() {
        let result = tax_amount(100.0, 8.375);
        assert!((result - 8.375).abs() < 0.0001);
    }

    #[test]
    fn calculates_total_with_combined_taxes() {
        let result = total_with_combined_taxes(100.0, &[10.0, 8.375]);
        assert!((result - 118.375).abs() < 0.0001);
    }

    #[test]
    fn calculates_zero_tax_amount() {
        let result = tax_amount(100.0, 0.0);
        assert!((result - 0.0).abs() < 0.0001);
    }

    #[test]
    fn calculates_zero_subtotal_with_combined_taxes() {
        let result = total_with_combined_taxes(0.0, &[10.0, 8.375]);
        assert!((result - 0.0).abs() < 0.0001);
    }
}