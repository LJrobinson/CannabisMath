plugins {
    kotlin("jvm") version "2.3.20"
    kotlin("plugin.serialization") version "2.3.20"
}

group = "com.cannabismath"
version = "0.3.0"

kotlin {
    jvmToolchain(21)
}

dependencies {
    testImplementation(kotlin("test"))
    testImplementation("org.jetbrains.kotlinx:kotlinx-serialization-json:1.7.3")
}

tasks.test {
    useJUnitPlatform()
}