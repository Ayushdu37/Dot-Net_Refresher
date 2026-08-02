using System;

Console.Write("Enter Marks for Subject 1: ");
string input1 = Console.ReadLine();

double mark1;

if (!double.TryParse(input1, out mark1))
{
    Console.WriteLine("Invalid Marks");
    return;
}

if (mark1 < 0 || mark1 > 100)
{
    Console.WriteLine("Marks must be between 0 and 100");
    return;
}

Console.Write("Enter Marks for Subject 2: ");
string input2 = Console.ReadLine();

double mark2;

if (!double.TryParse(input2, out mark2))
{
    Console.WriteLine("Invalid Marks");
    return;
}

if (mark2 < 0 || mark2 > 100)
{
    Console.WriteLine("Marks must be between 0 and 100");
    return;
}

Console.Write("Enter Marks for Subject 3: ");
string input3 = Console.ReadLine();

double mark3;

if (!double.TryParse(input3, out mark3))
{
    Console.WriteLine("Invalid Marks");
    return;
}

if (mark3 < 0 || mark3 > 100)
{
    Console.WriteLine("Marks must be between 0 and 100");
    return;
}

Console.Write("Enter Marks for Subject 4: ");
string input4 = Console.ReadLine();

double mark4;

if (!double.TryParse(input4, out mark4))
{
    Console.WriteLine("Invalid Marks");
    return;
}

if (mark4 < 0 || mark4 > 100)
{
    Console.WriteLine("Marks must be between 0 and 100");
    return;
}

Console.Write("Enter Marks for Subject 5: ");
string input5 = Console.ReadLine();

double mark5;

if (!double.TryParse(input5, out mark5))
{
    Console.WriteLine("Invalid Marks");
    return;
}

if (mark5 < 0 || mark5 > 100)
{
    Console.WriteLine("Marks must be between 0 and 100");
    return;
}

double total = mark1 + mark2 + mark3 + mark4 + mark5;
double average = total / 5;
double percentage = (total / 500) * 100;

average = Math.Round(average, 2);
percentage = Math.Round(percentage, 2);

Console.WriteLine();
Console.WriteLine($"Total Marks: {total}");
Console.WriteLine($"Average Marks: {average:F2}");
Console.WriteLine($"Percentage: {percentage:F2}%");