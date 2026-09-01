using System;

namespace Question2_SumOfPositiveIntegers
{
    internal class Program
    {
        static int SumPositiveUntilZero(int[] nums)
        {
            int sum = 0;

            foreach (int num in nums)
            {
                if (num == 0)
                {
                    break;
                }

                if (num < 0)
                {
                    continue;
                }

                sum += num;
            }

            return sum;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter space-separated integers: ");
            string? input = Console.ReadLine();

            int[] nums = string.IsNullOrWhiteSpace(input)
                ? Array.Empty<int>()
                : Array.ConvertAll(input.Split(' '), int.Parse);

            int result = SumPositiveUntilZero(nums);
            Console.WriteLine("Sum: " + result);
        }
    }
}
