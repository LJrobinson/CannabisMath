package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class PotencyTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesTotalThc() {
        val result = Potency.totalThc(1.0, 20.0)
        assertTrue(abs(result - 18.54) < epsilon)
    }

    @Test
    fun calculatesTotalCbd() {
        val result = Potency.totalCbd(0.5, 10.0)
        assertTrue(abs(result - 9.27) < epsilon)
    }
}