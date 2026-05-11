pub const GRAMS_PER_OUNCE: f64 = 28.0;
pub const OUNCES_PER_POUND: f64 = 16.0;
pub const GRAMS_PER_POUND: f64 = GRAMS_PER_OUNCE * OUNCES_PER_POUND;
pub const GRAMS_PER_EIGHTH: f64 = 3.5;

pub fn eighths_to_grams(eighths: f64) -> f64 {
    eighths * GRAMS_PER_EIGHTH
}

pub fn grams_to_ounces(grams: f64) -> f64 {
    grams / GRAMS_PER_OUNCE
}

pub fn ounces_to_grams(ounces: f64) -> f64 {
    ounces * GRAMS_PER_OUNCE
}

pub fn grams_to_pounds(grams: f64) -> f64 {
    grams / GRAMS_PER_POUND
}

pub fn pounds_to_grams(pounds: f64) -> f64 {
    pounds * GRAMS_PER_POUND
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn converts_eighths_to_grams() {
        let result = eighths_to_grams(24.0);
        assert!((result - 84.0).abs() < 0.0001);
    }

    #[test]
    fn converts_grams_to_ounces() {
        let result = grams_to_ounces(84.0);
        assert!((result - 3.0).abs() < 0.0001);
    }

    #[test]
    fn converts_ounces_to_grams() {
        let result = ounces_to_grams(3.0);
        assert!((result - 84.0).abs() < 0.0001);
    }

    #[test]
    fn converts_grams_to_pounds() {
        let result = grams_to_pounds(448.0);
        assert!((result - 1.0).abs() < 0.0001);
    }

    #[test]
    fn converts_pounds_to_grams() {
        let result = pounds_to_grams(1.0);
        assert!((result - 448.0).abs() < 0.0001);
    }
}