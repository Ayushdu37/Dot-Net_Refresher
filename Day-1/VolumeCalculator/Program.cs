using System;

Console.Write("Enter Length: ");
string lengthInput = Console.ReadLine();

double length;

if (!double.TryParse(lengthInput, out length))
{
    Console.WriteLine("Invalid Length");
    return;
}

if (length <= 0)
{
    Console.WriteLine("Length must be greater than zero");
    return;
}

Console.Write("Enter Width: ");
string widthInput = Console.ReadLine();

double width;

if (!double.TryParse(widthInput, out width))
{
    Console.WriteLine("Invalid Width");
    return;
}

if (width <= 0)
{
    Console.WriteLine("Width must be greater than zero");
    return;
}

Console.Write("Enter Height: ");
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

double volume = length * width * height;

volume = Math.Round(volume, 2);

Console.WriteLine();
Console.WriteLine($"Volume: {volume:F2}");