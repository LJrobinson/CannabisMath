package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class PricingTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesPricePerGram() {
        val result = Pricing.pricePerGram(35.0, 3.5)
        assertTrue(abs(result - 10.0) < epsilon)
    }

    @Test
    fun calculatesPricePerMg() {
        val result = Pricing.pricePerMg(25.0, 500.0)
        assertTrue(abs(result - 0.05) < epsilon)
    }

    @Test
    fun calculatesSmallPricePerMg() {
        val result = Pricing.pricePerMg(1.0, 1000.0)
        assertTrue(abs(result - 0.001) < epsilon)
    }

    @Test
    fun calculatesPricePerMgFromWeightAndPotency() {
        val result = Pricing.pricePerMgFromWeightAndPotency(35.0, 3.5, 20.0)
        assertTrue(abs(result - 0.05) < epsilon)
    }
}