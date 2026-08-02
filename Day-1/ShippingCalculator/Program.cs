using System;

Console.Write("Enter Package Type (Standard/Express): ");
string packageType = Console.ReadLine();

Console.Write("Enter Weight (kg): ");
string weightInput = Console.ReadLine();

double weight;

if (!double.TryParse(weightInput, out weight))
{
    Console.WriteLine("Invalid Weight");
    return;
}

if (weight <= 0)
{
    Console.WriteLine("Weight must be greater than zero");
    return;
}

if (weight > 1000)
{
    Console.WriteLine("Weight is too large");
    return;
}

Console.Write("Enter Distance (km): ");
string distanceInput = Console.ReadLine();

double distance;

if (!double.TryParse(distanceInput, out distance))
{
    Console.WriteLine("Invalid Distance");
    return;
}

if (distance <= 0)
{
    Console.WriteLine("Distance must be greater than zero");
    return;
}

if (distance > 10000)
{
    Console.WriteLine("Distance is too large");
    return;
}

Package package = new Package
{
    PackageType = packageType,
    Weight = weight,
    Distance = distance
};

IShippingCalculator calculator;

if (package.PackageType.Equals("Standard", StringComparison.OrdinalIgnoreCase))
{
    calculator = new StandardPackage();
}
else if (package.PackageType.Equals("Express", StringComparison.OrdinalIgnoreCase))
{
    calculator = new ExpressPackage();
}
else
{
    Console.WriteLine("Invalid Package Type");
    return;
}

double shippingCost = calculator.CalculateShippingCost(package.Weight, package.Distance);

Console.WriteLine();
Console.WriteLine($"Shipping Cost: {Math.Round(shippingCost, 2):F2}");