package com.cannabismath

object Potency {
    fun totalThc(thcPercent: Double, thcaPercent: Double): Double {
        return thcPercent + thcaPercent * 0.877
    }

    fun totalCbd(cbdPercent: Double, cbdaPercent: Double): Double {
        return cbdPercent + cbdaPercent * 0.877
    }
}