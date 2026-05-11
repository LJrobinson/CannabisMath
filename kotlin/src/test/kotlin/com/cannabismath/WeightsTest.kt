package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class WeightsTest {
    private val epsilon = 0.0001

    @Test
    fun convertsEighthsToGrams() {
        val result = Weights.eighthsToGrams(24.0)
        assertTrue(abs(result - 84.0) < epsilon)
    }

    @Test
    fun convertsGramsToRetailEighths() {
        val result = Weights.gramsToRetailEighths(28.0)
        assertTrue(abs(result - 8.0) < epsilon)
    }

    @Test
    fun convertsGramsToOunces() {
        val result = Weights.gramsToOunces(84.0)
        assertTrue(abs(result - 3.0) < epsilon)
    }

    @Test
    fun convertsOuncesToGrams() {
        val result = Weights.ouncesToGrams(3.0)
        assertTrue(abs(result - 84.0) < epsilon)
    }

    @Test
    fun convertsGramsToPounds() {
        val result = Weights.gramsToPounds(453.59237)
        assertTrue(abs(result - 1.0) < epsilon)
    }

    @Test
    fun convertsPoundsToGrams() {
        val result = Weights.poundsToGrams(1.0)
        assertTrue(abs(result - 453.59237) < epsilon)
    }

    @Test
    fun convertsHalfPoundToGrams() {
        val result = Weights.poundsToGrams(0.5)
        assertTrue(abs(result - 226.796185) < epsilon)
    }
}