package com.cannabismath

object Composites {
    fun pricePerMgFromWeightAndPotency(
        price: Double,
        weightGrams: Double,
        potencyPercent: Double
    ): Double {
        return Pricing.pricePerMgFromWeightAndPotency(
            price = price,
            weightGrams = weightGrams,
            potencyPercent = potencyPercent
        )
    }
}