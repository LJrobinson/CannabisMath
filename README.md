# CannabisMath

![.NET](https://img.shields.io/badge/.NET-8-blue)
![NuGet](https://img.shields.io/nuget/v/CannabisMath.Core)
![NPM](https://img.shields.io/npm/v/@ljrobinson/cannabismath)
![PyPI](https://img.shields.io/pypi/v/cannabismath)
![Tests](https://img.shields.io/badge/tests-132%20passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-green)

🚀 Overview

CannabisMath is a cross-platform cannabis calculation engine built for accuracy, consistency, and real-world retail workflows.

It provides deterministic calculations across:

C# (NuGet)
TypeScript (NPM)
Python (PyPI)

All implementations are validated against shared JSON fixtures, ensuring identical results across every platform.

🔥 Why CannabisMath?

Cannabis calculations are often inconsistent across systems.

Differences in:

rounding rules
potency formulas
weight assumptions
tax handling

lead to mismatched results, POS errors, and customer frustration.

CannabisMath provides a single source of truth.

✨ Features
Potency (THC / CBD)
Weight conversions
Dosing calculations
Pricing logic
Tax calculations
Rounding utilities (including nickel rounding)
Packaging breakdowns
Composite calculations
⚡ Example

Python:

value = CannabisValueCalculator.price_per_mg_from_weight_and_potency(35, 3.5, 20)

0.05
🧠 Architecture

One shared JSON fixture file is used to validate:

C#
TypeScript
Python

Ensuring no calculation drift.

📦 Installation

C#:
dotnet add package CannabisMath.Core

TypeScript:
npm install @ljrobinson/cannabismath

Python:
pip install cannabismath

🏗️ Use Cases
POS systems
Analytics dashboards
Inventory tools
Data pipelines
Consumer calculators
⚠️ Disclaimer

CannabisMath is a calculation library only.

📄 License

MIT