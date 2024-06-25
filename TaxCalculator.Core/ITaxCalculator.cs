namespace TaxCalculator.Core;

/// <summary>
/// This is the public inteface used by our client and may not be changed
/// </summary>
public interface ITaxCalculator
{
    double GetStandardTaxRate(Commodity commodity);
    void SetCustomTaxRate(Commodity commodity, double rate);
    double GetTaxRateForDateTime(Commodity commodity, DateTime date);
    double GetCurrentTaxRate(Commodity commodity);
}