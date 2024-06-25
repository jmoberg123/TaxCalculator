﻿using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using TaxCalculatorInterviewTests;

namespace TaxCalculator.Core.Tests;

public class CustomTaxRateRepositoryTests
{
    private CustomTaxRateRepository _customTaxRateRepository;
    private IClock _clock;
    private readonly Fixture _fixture = new();

    [SetUp]
    public void SetUp()
    {
        _clock = Substitute.For<IClock>();
        _customTaxRateRepository = new CustomTaxRateRepository(_clock);
    }

    [Test]
    public void Add_ShouldAddACustomTaxRateWithTheProvidedValues()
    {
        //Arrange
        const Commodity commodity = Commodity.Alcohol;
        const double rate = 0.1;
        var timestamp = _fixture.Create<DateTime>();
        _clock.Now.Returns(timestamp);

        //Act
        _customTaxRateRepository.Add(commodity, rate);

        //Assert
        _customTaxRateRepository.GetAll()
            .Single()
            .Should().BeEquivalentTo(new CustomTaxRate(commodity, rate, timestamp));
    }

    [Test]
    public void Add_WhenLaterCustomTaxRateAlreadyExists_ShouldReplaceTheCustomTaxRate()
    {
        //Arrange
        const Commodity commodity = Commodity.Alcohol;

        //Add an existing custom tax rate with a later timestamp
        var duplicateTimeStamp = new DateTime(2024, 06, 26);
        _clock.Now.Returns(duplicateTimeStamp);
        _customTaxRateRepository.Add(commodity, 0.2);

        //Then add a new custom tax rate with the "correct" current timestamp
        const double rate = 0.1;
        var timestamp = new DateTime(2024, 06, 25);
        _clock.Now.Returns(timestamp);

        //Act
        _customTaxRateRepository.Add(commodity, rate);

        //Assert
        _customTaxRateRepository.GetAll()
            .Single()
            .Should().BeEquivalentTo(new CustomTaxRate(commodity, rate, timestamp));
    }
}