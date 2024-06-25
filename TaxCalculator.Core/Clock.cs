namespace TaxCalculator.Core;

public class Clock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}