using FluentAssertions;
using NUnit.Framework;
using TaxCalculatorInterviewTests;

namespace TaxCalculator.Core.Tests;
using TaxCalculator = TaxCalculatorInterviewTests.TaxCalculator;

public class TaxCalculatorTests
{

    private TaxCalculator _taxCalculator;

    [SetUp]
    public void SetUp()
    {
        _taxCalculator = new TaxCalculator();
    }

    [TestCase(Commodity.Default, 0.25)]
    [TestCase(Commodity.Alcohol, 0.25)]
    [TestCase(Commodity.Food, 0.12)]
    [TestCase(Commodity.FoodServices, 0.12)]
    [TestCase(Commodity.Literature, 0.6)]
    [TestCase(Commodity.Transport, 0.6)]
    [TestCase(Commodity.CulturalServices, 0.6)]
    public void GetStandardTaxRate_ShouldReturnExpectedRates(Commodity commodity, double expectedRate)
    {
        //Act
        var rate = _taxCalculator.GetStandardTaxRate(commodity);

        //Assert
        rate.Should().Be(expectedRate);
    }
}