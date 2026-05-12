package com.cannabismath

import java.io.File
import kotlin.math.abs
import kotlin.test.Test
import kotlin.test.assertEquals
import kotlin.test.assertTrue
import kotlinx.serialization.Serializable
import kotlinx.serialization.json.Json

class FixtureParityTest {
    private val epsilon = 0.0001

    private val json = Json {
        ignoreUnknownKeys = true
    }

    private fun loadFixtures(): CoreFixtures {
        val fixtureFile = File("../shared/test-fixtures/core-fixtures.json")
        return json.decodeFromString<CoreFixtures>(fixtureFile.readText())
    }

    private fun assertClose(actual: Double, expected: Double, name: String) {
        assertTrue(
            abs(actual - expected) < epsilon,
            "$name: expected $expected, got $actual"
        )
    }

    @Test
    fun potencyMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.potency) {
            case.expectedTotalThc?.let { expected ->
                val actual = Potency.totalThc(
                    case.thcPercent ?: 0.0,
                    case.thcaPercent ?: 0.0
                )
                assertClose(actual, expected, case.name)
            }

            case.expectedTotalCbd?.let { expected ->
                val actual = Potency.totalCbd(
                    case.cbdPercent ?: 0.0,
                    case.cbdaPercent ?: 0.0
                )
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun weightsMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.weights) {
            case.expectedRetailEighths?.let { expected ->
                val actual = Weights.gramsToRetailEighths(case.grams ?: 0.0)
                assertClose(actual, expected, case.name)
            }

            case.expectedGrams?.let { expected ->
                val actual = Weights.poundsToGrams(case.pounds ?: 0.0)
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun dosingMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.dosing) {
            case.expectedTotalMg?.let { expected ->
                val actual = Dosing.totalMgFromWeightAndPotency(
                    case.weightGrams ?: 0.0,
                    case.potencyPercent
                )
                assertClose(actual, expected, case.name)
            }

            case.expectedMg?.let { expected ->
                val actual = Dosing.dabMg(
                    case.potencyPercent,
                    case.dabSizeGrams ?: 0.0
                )
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun pricingMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.pricing) {
            case.expectedPricePerGram?.let { expected ->
                val actual = Pricing.pricePerGram(case.price, case.grams ?: 0.0)
                assertClose(actual, expected, case.name)
            }

            case.expectedPricePerMg?.let { expected ->
                val actual = Pricing.pricePerMg(case.price, case.totalMg ?: 0.0)
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun roundingMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.rounding) {
            case.expectedRounded?.let { expected ->
                val actual = Rounding.roundToNearestNickel(case.value ?: 0.0)
                assertClose(actual, expected, case.name)
            }

            case.expectedDifference?.let { expected ->
                val actual = Rounding.roundingDifference(
                    case.originalValue ?: 0.0,
                    case.roundedValue ?: 0.0
                )
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun taxesMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.taxes) {
            case.expectedTaxAmount?.let { expected ->
                val actual = Taxes.taxAmount(
                    case.subtotal,
                    case.taxRatePercent ?: 0.0
                )
                assertClose(actual, expected, case.name)
            }

            case.expectedTotal?.let { expected ->
                val actual = Taxes.totalWithCombinedTaxes(
                    case.subtotal,
                    case.taxRates ?: emptyList()
                )
                assertClose(actual, expected, case.name)
            }
        }
    }

    @Test
    fun packagingMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.packaging) {
            val actual = Packaging.packagingBreakdown(
                case.totalGrams,
                case.gramsPerUnit
            )

            assertEquals(
                case.expectedFullUnits,
                actual.fullUnits,
                "${case.name}: expected ${case.expectedFullUnits} full units, got ${actual.fullUnits}"
            )

            assertClose(
                actual.remainingGrams,
                case.expectedRemainingGrams,
                case.name
            )
        }
    }

    @Test
    fun compositesMatchesSharedFixtures() {
        val fixtures = loadFixtures()

        for (case in fixtures.composites) {
            val actual = Composites.pricePerMgFromWeightAndPotency(
                case.price,
                case.weightGrams,
                case.potencyPercent
            )

            assertClose(actual, case.expectedPricePerMg, case.name)
        }
    }
}

@Serializable
data class CoreFixtures(
    val potency: List<PotencyFixture>,
    val weights: List<WeightFixture>,
    val dosing: List<DosingFixture>,
    val pricing: List<PricingFixture>,
    val rounding: List<RoundingFixture>,
    val taxes: List<TaxFixture>,
    val packaging: List<PackagingFixture>,
    val composites: List<CompositeFixture>
)

@Serializable
data class PotencyFixture(
    val name: String,
    val thcPercent: Double? = null,
    val thcaPercent: Double? = null,
    val expectedTotalThc: Double? = null,
    val cbdPercent: Double? = null,
    val cbdaPercent: Double? = null,
    val expectedTotalCbd: Double? = null
)

@Serializable
data class WeightFixture(
    val name: String,
    val grams: Double? = null,
    val pounds: Double? = null,
    val expectedRetailEighths: Double? = null,
    val expectedGrams: Double? = null
)

@Serializable
data class DosingFixture(
    val name: String,
    val weightGrams: Double? = null,
    val potencyPercent: Double,
    val dabSizeGrams: Double? = null,
    val expectedTotalMg: Double? = null,
    val expectedMg: Double? = null
)

@Serializable
data class PricingFixture(
    val name: String,
    val price: Double,
    val grams: Double? = null,
    val totalMg: Double? = null,
    val expectedPricePerGram: Double? = null,
    val expectedPricePerMg: Double? = null
)

@Serializable
data class RoundingFixture(
    val name: String,
    val value: Double? = null,
    val expectedRounded: Double? = null,
    val originalValue: Double? = null,
    val roundedValue: Double? = null,
    val expectedDifference: Double? = null
)

@Serializable
data class TaxFixture(
    val name: String,
    val subtotal: Double,
    val taxRatePercent: Double? = null,
    val taxRates: List<Double>? = null,
    val expectedTaxAmount: Double? = null,
    val expectedTotal: Double? = null
)

@Serializable
data class PackagingFixture(
    val name: String,
    val totalGrams: Double,
    val gramsPerUnit: Double,
    val expectedFullUnits: Long,
    val expectedRemainingGrams: Double
)

@Serializable
data class CompositeFixture(
    val name: String,
    val price: Double,
    val weightGrams: Double,
    val potencyPercent: Double,
    val expectedPricePerMg: Double
)