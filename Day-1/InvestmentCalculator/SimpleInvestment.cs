public class SimpleInvestment : IInvestmentCalculator
{
    public double CalculateReturn(double principal, double rate, double years)
    {
        return principal + (principal * rate * years) / 100;
    }
}