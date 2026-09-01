using System;

namespace Question3_ObjectArraySum
{
    internal class Program
    {
        static int SumIntegers(object[] values)
        {
            int sum = 0;

            foreach (object item in values)
            {
                if (item is int x)
                {
                    sum += x;
                }
            }

            return sum;
        }

        static void Main(string[] args)
        {
            object[] values = new object[]
            {
                10,
                "hello",
                true,
                25,
                null!,
                3.14,
                15
            };

            int sum = SumIntegers(values);
            Console.WriteLine("Sum of integers: " + sum);
        }
    }
}
