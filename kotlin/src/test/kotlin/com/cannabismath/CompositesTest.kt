package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class CompositesTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesPricePerMgFromWeightAndPotency() {
        val result = Composites.pricePerMgFromWeightAndPotency(35.0, 3.5, 20.0)
        assertTrue(abs(result - 0.05) < epsilon)
    }

    @Test
    fun calculatesLowPricePerMgFromHighPotency() {
        val result = Composites.pricePerMgFromWeightAndPotency(20.0, 1.0, 80.0)
        assertTrue(abs(result - 0.025) < epsilon)
    }
}