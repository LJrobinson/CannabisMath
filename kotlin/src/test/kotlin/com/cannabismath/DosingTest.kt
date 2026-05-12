package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class DosingTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesTotalMgFromWeightAndPotency() {
        val result = Dosing.totalMgFromWeightAndPotency(3.5, 20.0)
        assertTrue(abs(result - 700.0) < epsilon)
    }

    @Test
    fun calculatesDabMg() {
        val result = Dosing.dabMg(80.0, 0.05)
        assertTrue(abs(result - 40.0) < epsilon)
    }
}