﻿namespace TaxCalculatorInterviewTests;

public record CustomTaxRate(Commodity Commodity, double Rate, DateTime TimeStamp) : TaxRate(Commodity, Rate);