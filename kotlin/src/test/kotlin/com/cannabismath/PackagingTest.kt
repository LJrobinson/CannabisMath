package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertEquals
import kotlin.test.assertTrue

class PackagingTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesPoundToEighthsBreakdown() {
        val result = Packaging.packagingBreakdown(453.59237, 3.5)

        assertEquals(129, result.fullUnits)
        assertTrue(abs(result.remainingGrams - 2.09237) < epsilon)
    }

    @Test
    fun calculatesExactEighthBreakdown() {
        val result = Packaging.packagingBreakdown(28.0, 3.5)

        assertEquals(8, result.fullUnits)
        assertTrue(abs(result.remainingGrams - 0.0) < epsilon)
    }

    @Test
    fun calculatesLessThanOneUnitBreakdown() {
        val result = Packaging.packagingBreakdown(2.0, 3.5)

        assertEquals(0, result.fullUnits)
        assertTrue(abs(result.remainingGrams - 2.0) < epsilon)
    }
}