pub fn total_thc(thc: f64, thca: f64) -> f64 {
    thc + thca * 0.877
}

pub fn total_cbd(cbd: f64, cbda: f64) -> f64 {
    cbd + cbda * 0.877
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn calculates_total_thc() {
        let result = total_thc(1.0, 20.0);
        assert!((result - 18.54).abs() < 0.0001);
    }

    #[test]
    fn calculates_total_cbd() {
        let result = total_cbd(0.5, 10.0);
        assert!((result - 9.27).abs() < 0.0001);
    }
}