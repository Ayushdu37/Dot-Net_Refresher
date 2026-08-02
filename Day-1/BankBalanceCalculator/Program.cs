using System;

Console.Write("Enter Opening Balance: ");
string openingBalanceInput = Console.ReadLine();

double openingBalance;

if (!double.TryParse(openingBalanceInput, out openingBalance))
{
    Console.WriteLine("Invalid Opening Balance");
    return;
}

if (openingBalance < 0)
{
    Console.WriteLine("Opening Balance cannot be negative");
    return;
}

Console.Write("Enter Total Deposits: ");
string depositsInput = Console.ReadLine();

double deposits;

if (!double.TryParse(depositsInput, out deposits))
{
    Console.WriteLine("Invalid Deposits");
    return;
}

if (deposits < 0)
{
    Console.WriteLine("Deposits cannot be negative");
    return;
}

Console.Write("Enter Total Withdrawals: ");
string withdrawalsInput = Console.ReadLine();

double withdrawals;

if (!double.TryParse(withdrawalsInput, out withdrawals))
{
    Console.WriteLine("Invalid Withdrawals");
    return;
}

if (withdrawals < 0)
{
    Console.WriteLine("Withdrawals cannot be negative");
    return;
}

double availableBalance = openingBalance + deposits;

if (withdrawals > availableBalance)
{
    Console.WriteLine("Error: Withdrawals exceed available balance");
    return;
}

double finalBalance = availableBalance - withdrawals;

finalBalance = Math.Round(finalBalance, 2);

Console.WriteLine();
Console.WriteLine($"Updated Balance: {finalBalance:F2}");