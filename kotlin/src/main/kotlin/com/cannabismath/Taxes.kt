package com.cannabismath

object Taxes {
    fun taxAmount(subtotal: Double, taxRatePercent: Double): Double {
        return subtotal * (taxRatePercent / 100.0)
    }

    fun totalWithCombinedTaxes(subtotal: Double, taxRates: List<Double>): Double {
        val totalTaxRate = taxRates.sum()
        return subtotal + taxAmount(subtotal, totalTaxRate)
    }
}