namespace TaxCalculatorInterviewTests;

public class Clock : IClock
{
    public DateTime Now => DateTime.UtcNow;
}