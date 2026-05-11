pub fn total_mg_from_weight_and_potency(weight_grams: f64, potency_percent: f64) -> f64 {
    weight_grams * 1000.0 * (potency_percent / 100.0)
}

pub fn dab_mg(potency_percent: f64, dab_size_grams: f64) -> f64 {
    total_mg_from_weight_and_potency(dab_size_grams, potency_percent)
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_total_mg_from_weight_and_potency() {
        let result = total_mg_from_weight_and_potency(3.5, 20.0);
        assert!((result - 700.0).abs() < 0.0001);
    }

    #[test]
    fn calculates_dab_mg() {
        let result = dab_mg(80.0, 0.05);
        assert!((result - 40.0).abs() < 0.0001);
    }
}