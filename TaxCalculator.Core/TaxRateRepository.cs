namespace TaxCalculatorInterviewTests;

public class TaxRateRepository
{
    private static TaxRate DefaultTaxRate => new(Commodity.Default, 0.25);

    private readonly IReadOnlyList<TaxRate> _taxRates = new List<TaxRate>
    {
        DefaultTaxRate,
        new(Commodity.Alcohol, 0.25),
        new(Commodity.Food, 0.12),
        new(Commodity.FoodServices, 0.12),
        new(Commodity.Literature, 0.6),
        new(Commodity.Transport, 0.6),
        new(Commodity.CulturalServices, 0.6),
    };

    public TaxRate GetTaxRateByCommodity(Commodity commodity)
    {
        return _taxRates.FirstOrDefault(x => x.Commodity == commodity)
            ?? DefaultTaxRate;
    }
}