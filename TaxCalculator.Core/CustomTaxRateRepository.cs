namespace TaxCalculator.Core;

public class CustomTaxRateRepository(IClock clock)
{
    private readonly List<CustomTaxRate> _customTaxRates = [];

    public void Add(Commodity commodity, double rate)
    {
        var customTaxRateToAdd = new CustomTaxRate(commodity, rate, clock.Now);

        var latestCustomTaxRate = _customTaxRates.MaxBy(x => x.TimeStamp);

        //If there is a custom tax rate for the same commodity with a later timestamp, something has gone wrong.
        //Replace this value with the new one.
        if (latestCustomTaxRate != null
            && latestCustomTaxRate.Commodity == customTaxRateToAdd.Commodity
            && latestCustomTaxRate.TimeStamp >= customTaxRateToAdd.TimeStamp)
        {
            _customTaxRates.Remove(latestCustomTaxRate);
        }

        _customTaxRates.Add(customTaxRateToAdd);
    }

    public CustomTaxRate? GetCurrentCustomTaxRateByCommodity(Commodity commodity)
    {
        return _customTaxRates.Where(x => x.Commodity == commodity)
            .MaxBy(x => x.TimeStamp);
    }

    public CustomTaxRate? GetCustomTaxRateByCommodityAndDate(Commodity commodity, DateTime date)
    {
        return _customTaxRates.Where(x => x.Commodity == commodity
            && x.TimeStamp <= date)
            .MaxBy(x => x.TimeStamp);
    }

    public IEnumerable<CustomTaxRate> GetAll()
    {
        return _customTaxRates;
    }
}