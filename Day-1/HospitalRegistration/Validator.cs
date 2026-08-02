using System;

public class Validator
{
    public static int ReadAge()
    {
        while (true)
        {
            Console.Write("Enter Age: ");

            string input = Console.ReadLine();

            int age;

            if (!int.TryParse(input, out age))
            {
                Console.WriteLine("Invalid Age");
                continue;
            }

            if (age <= 0)
            {
                Console.WriteLine("Age must be greater than zero");
                continue;
            }

            return age;
        }
    }

    public static double ReadWeight()
    {
        while (true)
        {
            Console.Write("Enter Weight (kg): ");

            string input = Console.ReadLine();

            double weight;

            if (!double.TryParse(input, out weight))
            {
                Console.WriteLine("Invalid Weight");
                continue;
            }

            if (weight <= 0)
            {
                Console.WriteLine("Weight must be greater than zero");
                continue;
            }

            return weight;
        }
    }

    public static double ReadHeight()
    {
        while (true)
        {
            Console.Write("Enter Height (m): ");

            string input = Console.ReadLine();

            double height;

            if (!double.TryParse(input, out height))
            {
                Console.WriteLine("Invalid Height");
                continue;
            }

            if (height <= 0)
            {
                Console.WriteLine("Height must be greater than zero");
                continue;
            }

            return height;
        }
    }

    public static double ReadTemperature()
    {
        while (true)
        {
            Console.Write("Enter Temperature (°C): ");

            string input = Console.ReadLine();

            double temperature;

            if (!double.TryParse(input, out temperature))
            {
                Console.WriteLine("Invalid Temperature");
                continue;
            }

            if (temperature < 30 || temperature > 45)
            {
                Console.WriteLine("Temperature must be between 30 and 45");
                continue;
            }

            return temperature;
        }
    }
}