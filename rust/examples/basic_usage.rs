use cannabismath::{
    packaging_breakdown, price_per_mg_from_weight_and_potency, total_thc,
};

fn main() {
    let total_thc_percent = total_thc(1.2, 24.8);
    println!("Total THC: {:.4}%", total_thc_percent);

    let price_per_mg = price_per_mg_from_weight_and_potency(35.0, 3.5, 20.0);
    println!("Price per mg THC: ${:.4}", price_per_mg);

    let breakdown = packaging_breakdown(453.59237, 3.5);
    println!(
        "Packaging breakdown: {} full eighths, {:.5}g remaining",
        breakdown.full_units, breakdown.remaining_grams
    );
}