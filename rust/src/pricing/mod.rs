pub fn price_per_gram(price: f64, weight_grams: f64) -> f64 {
    price / weight_grams
}

pub fn price_per_mg_from_weight_and_potency(
    price: f64,
    weight_grams: f64,
    potency_percent: f64,
) -> f64 {
    let total_mg = weight_grams * 1000.0 * (potency_percent / 100.0);
    price / total_mg
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_price_per_gram() {
        let result = price_per_gram(35.0, 3.5);
        assert!((result - 10.0).abs() < 0.0001);
    }

    #[test]
    fn calculates_price_per_mg_from_weight_and_potency() {
        let result = price_per_mg_from_weight_and_potency(35.0, 3.5, 20.0);
        assert!((result - 0.05).abs() < 0.0001);
    }
}