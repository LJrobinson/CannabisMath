package com.cannabismath

import kotlin.math.pow
import kotlin.math.round

object Rounding {
    fun roundToDecimals(value: Double, decimals: Int): Double {
        val factor = 10.0.pow(decimals)
        return round(value * factor) / factor
    }

    fun roundToNearestNickel(value: Double): Double {
        return round(value / 0.05) * 0.05
    }

    fun roundingDifference(originalValue: Double, roundedValue: Double): Double {
        return roundedValue - originalValue
    }
}