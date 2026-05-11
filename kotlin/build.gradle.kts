plugins {
    kotlin("jvm") version "2.3.20"
}

group = "com.cannabismath"
version = "0.1.0"

kotlin {
    jvmToolchain(21)
}

dependencies {
    testImplementation(kotlin("test"))
}

tasks.test {
    useJUnitPlatform()
}