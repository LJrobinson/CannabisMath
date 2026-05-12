package com.cannabismath

object Pricing {
    fun pricePerGram(price: Double, weightGrams: Double): Double {
        return price / weightGrams
    }

    fun pricePerMg(price: Double, totalMg: Double): Double {
        return price / totalMg
    }

    fun pricePerMgFromWeightAndPotency(
        price: Double,
        weightGrams: Double,
        potencyPercent: Double
    ): Double {
        val totalMg = Dosing.totalMgFromWeightAndPotency(weightGrams, potencyPercent)
        return pricePerMg(price, totalMg)
    }
}