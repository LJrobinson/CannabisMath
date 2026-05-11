package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class RoundingTest {
    private val epsilon = 0.0001

    @Test
    fun roundsToTwoDecimals() {
        val result = Rounding.roundToDecimals(10.555, 2)
        assertTrue(abs(result - 10.56) < epsilon)
    }

    @Test
    fun roundsToZeroDecimals() {
        val result = Rounding.roundToDecimals(10.55, 0)
        assertTrue(abs(result - 11.0) < epsilon)
    }

    @Test
    fun roundsToNearestNickelUp() {
        val result = Rounding.roundToNearestNickel(10.53)
        assertTrue(abs(result - 10.55) < epsilon)
    }

    @Test
    fun roundsToNearestNickelDown() {
        val result = Rounding.roundToNearestNickel(10.52)
        assertTrue(abs(result - 10.50) < epsilon)
    }

    @Test
    fun calculatesRoundingDifference() {
        val result = Rounding.roundingDifference(10.03, 10.05)
        assertTrue(abs(result - 0.02) < epsilon)
    }

    @Test
    fun calculatesNegativeRoundingDifference() {
        val result = Rounding.roundingDifference(10.09, 10.05)
        assertTrue(abs(result + 0.04) < epsilon)
    }
}