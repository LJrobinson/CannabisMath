package com.cannabismath

object Dosing {
    fun totalMgFromWeightAndPotency(weightGrams: Double, potencyPercent: Double): Double {
        return weightGrams * 1000.0 * (potencyPercent / 100.0)
    }

    fun dabMg(potencyPercent: Double, dabSizeGrams: Double): Double {
        return totalMgFromWeightAndPotency(dabSizeGrams, potencyPercent)
    }
}