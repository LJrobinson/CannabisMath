pub fn round_to_decimals(value: f64, decimals: i32) -> f64 {
    let factor = 10_f64.powi(decimals);
    (value * factor).round() / factor
}

pub fn round_to_nearest_nickel(value: f64) -> f64 {
    (value / 0.05).round() * 0.05
}

pub fn rounding_difference(original_value: f64, rounded_value: f64) -> f64 {
    rounded_value - original_value
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn rounds_to_two_decimals() {
        let result = round_to_decimals(10.555, 2);
        assert!((result - 10.56).abs() < 0.0001);
    }

    #[test]
    fn rounds_to_zero_decimals() {
        let result = round_to_decimals(10.55, 0);
        assert!((result - 11.0).abs() < 0.0001);
    }

    #[test]
    fn rounds_to_nearest_nickel_up() {
        let result = round_to_nearest_nickel(10.53);
        assert!((result - 10.55).abs() < 0.0001);
    }

    #[test]
    fn rounds_to_nearest_nickel_down() {
        let result = round_to_nearest_nickel(10.52);
        assert!((result - 10.50).abs() < 0.0001);
    }

    #[test]
    fn calculates_rounding_difference() {
        let result = rounding_difference(10.03, 10.05);
        assert!((result - 0.02).abs() < 0.0001);
    }

    #[test]
    fn calculates_negative_rounding_difference() {
        let result = rounding_difference(10.09, 10.05);
        assert!((result - -0.04).abs() < 0.0001);
    }
}