using System;

Console.Write("Enter Investment Type (Simple/Compound): ");
string investmentType = Console.ReadLine();

Console.Write("Enter Principal Amount: ");
string principalInput = Console.ReadLine();

double principal;

if (!double.TryParse(principalInput, out principal))
{
    Console.WriteLine("Invalid Principal Amount");
    return;
}

if (principal <= 0)
{
    Console.WriteLine("Principal Amount must be greater than zero");
    return;
}

Console.Write("Enter Annual Rate (%): ");
string rateInput = Console.ReadLine();

double rate;

if (!double.TryParse(rateInput, out rate))
{
    Console.WriteLine("Invalid Rate");
    return;
}

if (rate < 0 || rate > 100)
{
    Console.WriteLine("Rate must be between 0 and 100");
    return;
}

Console.Write("Enter Duration (Years): ");
string durationInput = Console.ReadLine();

double years;

if (!double.TryParse(durationInput, out years))
{
    Console.WriteLine("Invalid Duration");
    return;
}

if (years <= 0)
{
    Console.WriteLine("Duration must be greater than zero");
    return;
}

Investment investment = new Investment
{
    InvestmentType = investmentType,
    Principal = principal,
    AnnualRate = rate,
    Duration = years
};

IInvestmentCalculator calculator;

if (investment.InvestmentType.Equals("Simple", StringComparison.OrdinalIgnoreCase))
{
    calculator = new SimpleInvestment();
}
else if (investment.InvestmentType.Equals("Compound", StringComparison.OrdinalIgnoreCase))
{
    calculator = new CompoundInvestment();
}
else
{
    Console.WriteLine("Invalid Investment Type");
    return;
}

double amount = calculator.CalculateReturn(
    investment.Principal,
    investment.AnnualRate,
    investment.Duration);

Console.WriteLine();
Console.WriteLine($"Projected Investment Value: {Math.Round(amount, 2):F2}");