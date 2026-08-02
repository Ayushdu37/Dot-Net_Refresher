using System;

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

Console.Write("Enter Height (meters): ");
string heightInput = Console.ReadLine();

double height;

if (!double.TryParse(heightInput, out height))
{
    Console.WriteLine("Invalid Height");
    return;
}

if (height <= 0)
{
    Console.WriteLine("Height must be greater than zero");
    return;
}

double bmi = weight / (height * height);

bmi = Math.Round(bmi, 2);

Console.WriteLine();
Console.WriteLine($"BMI: {bmi:F2}");

if (bmi < 18.5)
{
    Console.WriteLine("Category: Underweight");
}
else if (bmi < 25)
{
    Console.WriteLine("Category: Normal Weight");
}
else if (bmi < 30)
{
    Console.WriteLine("Category: Overweight");
}
else
{
    Console.WriteLine("Category: Obese");
}