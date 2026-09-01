using System;

namespace Question8_ParsingSumIntegers
{
    internal class Program
    {
        static int SumParsableIntegers(string[] tokens)
        {
            int sum = 0;

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out int value))
                {
                    sum += value;
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter space-separated tokens: ");
            string? input = Console.ReadLine();

            string[] tokens = string.IsNullOrWhiteSpace(input)
                ? Array.Empty<string>()
                : input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int result = SumParsableIntegers(tokens);
            Console.WriteLine("Sum of integers: " + result);
        }
    }
}
