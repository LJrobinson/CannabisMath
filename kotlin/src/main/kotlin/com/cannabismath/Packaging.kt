package com.cannabismath

data class PackagingBreakdown(
    val fullUnits: Long,
    val remainingGrams: Double
)

object Packaging {
    fun packagingBreakdown(totalGrams: Double, gramsPerUnit: Double): PackagingBreakdown {
        val fullUnits = kotlin.math.floor(totalGrams / gramsPerUnit).toLong()
        val remainingGrams = totalGrams - (fullUnits * gramsPerUnit)

        return PackagingBreakdown(
            fullUnits = fullUnits,
            remainingGrams = remainingGrams
        )
    }
}