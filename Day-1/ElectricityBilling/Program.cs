using System;

Console.Write("Enter Customer Type (Residential/Commercial): ");
string customerType = Console.ReadLine();

Console.Write("Enter Units Consumed: ");
string unitsInput = Console.ReadLine();

double units;

if (!double.TryParse(unitsInput, out units))
{
    Console.WriteLine("Invalid Units");
    return;
}

if (units < 0)
{
    Console.WriteLine("Units cannot be negative");
    return;
}

Console.Write("Enter Rate Per Unit: ");
string rateInput = Console.ReadLine();

double rate;

if (!double.TryParse(rateInput, out rate))
{
    Console.WriteLine("Invalid Rate");
    return;
}

if (rate < 0)
{
    Console.WriteLine("Rate cannot be negative");
    return;
}

Console.Write("Enter Fixed Charges: ");
string fixedInput = Console.ReadLine();

double fixedCharges;

if (!double.TryParse(fixedInput, out fixedCharges))
{
    Console.WriteLine("Invalid Fixed Charges");
    return;
}

if (fixedCharges < 0)
{
    Console.WriteLine("Fixed Charges cannot be negative");
    return;
}

IBillCalculator calculator;

if (customerType.Equals("Residential", StringComparison.OrdinalIgnoreCase))
{
    calculator = new ResidentialCustomer();
}
else if (customerType.Equals("Commercial", StringComparison.OrdinalIgnoreCase))
{
    calculator = new CommercialCustomer();
}
else
{
    Console.WriteLine("Invalid Customer Type");
    return;
}

double bill = calculator.CalculateBill(units, rate, fixedCharges);

Console.WriteLine();
Console.WriteLine($"Total Bill: {Math.Round(bill, 2):F2}");