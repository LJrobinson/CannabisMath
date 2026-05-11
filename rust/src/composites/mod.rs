use crate::pricing::price_per_mg_from_weight_and_potency;

pub fn composite_price_per_mg_from_weight_and_potency(
    price: f64,
    weight_grams: f64,
    potency_percent: f64,
) -> f64 {
    price_per_mg_from_weight_and_potency(price, weight_grams, potency_percent)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_price_per_mg_from_weight_and_potency() {
        let result = composite_price_per_mg_from_weight_and_potency(35.0, 3.5, 20.0);
        assert!((result - 0.05).abs() < 0.0001);
    }

    #[test]
    fn calculates_low_price_per_mg_from_high_potency() {
        let result = composite_price_per_mg_from_weight_and_potency(20.0, 1.0, 80.0);
        assert!((result - 0.025).abs() < 0.0001);
    }
}