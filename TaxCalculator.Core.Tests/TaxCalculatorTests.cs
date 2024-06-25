using FluentAssertions;
using NUnit.Framework;

namespace TaxCalculator.Core.Tests;
using TaxCalculator = TaxCalculator;

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
    [TestCase(Commodity.Literature, 0.06)]
    [TestCase(Commodity.Transport, 0.06)]
    [TestCase(Commodity.CulturalServices, 0.06)]
    public void GetStandardTaxRate_ShouldReturnExpectedRates(Commodity commodity, double expectedRate)
    {
        //Act
        var rate = _taxCalculator.GetStandardTaxRate(commodity);

        //Assert
        rate.Should().Be(expectedRate);
    }
}