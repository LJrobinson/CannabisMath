package com.cannabismath

object Weights {
    const val GRAMS_PER_OUNCE: Double = 28.0
    const val GRAMS_PER_POUND: Double = 453.59237
    const val GRAMS_PER_EIGHTH: Double = 3.5

    fun eighthsToGrams(eighths: Double): Double {
        return eighths * GRAMS_PER_EIGHTH
    }

    fun gramsToRetailEighths(grams: Double): Double {
        return grams / GRAMS_PER_EIGHTH
    }

    fun gramsToOunces(grams: Double): Double {
        return grams / GRAMS_PER_OUNCE
    }

    fun ouncesToGrams(ounces: Double): Double {
        return ounces * GRAMS_PER_OUNCE
    }

    fun gramsToPounds(grams: Double): Double {
        return grams / GRAMS_PER_POUND
    }

    fun poundsToGrams(pounds: Double): Double {
        return pounds * GRAMS_PER_POUND
    }
}