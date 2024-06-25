namespace TaxCalculator.Core;

public interface IClock
{
    DateTime Now { get; }
}