package com.cannabismath

import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertTrue

class TaxesTest {
    private val epsilon = 0.0001

    @Test
    fun calculatesTaxAmount() {
        val result = Taxes.taxAmount(100.0, 8.375)
        assertTrue(abs(result - 8.375) < epsilon)
    }

    @Test
    fun calculatesTotalWithCombinedTaxes() {
        val result = Taxes.totalWithCombinedTaxes(100.0, listOf(10.0, 8.375))
        assertTrue(abs(result - 118.375) < epsilon)
    }

    @Test
    fun calculatesZeroTaxAmount() {
        val result = Taxes.taxAmount(100.0, 0.0)
        assertTrue(abs(result - 0.0) < epsilon)
    }

    @Test
    fun calculatesZeroSubtotalWithCombinedTaxes() {
        val result = Taxes.totalWithCombinedTaxes(0.0, listOf(10.0, 8.375))
        assertTrue(abs(result - 0.0) < epsilon)
    }
}