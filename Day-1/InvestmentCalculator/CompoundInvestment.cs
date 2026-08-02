using System;

public class CompoundInvestment : IInvestmentCalculator
{
    public double CalculateReturn(double principal, double rate, double years)
    {
        return principal * Math.Pow(1 + rate / 100, years);
    }
}