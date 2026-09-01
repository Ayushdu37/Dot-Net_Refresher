using System;

namespace Question6_NullableAverage
{
    internal class Program
    {
        static double? ComputeAverage(double?[] values)
        {
            double sum = 0.0;
            int count = 0;

            foreach (double? val in values)
            {
                if (val.HasValue)
                {
                    sum += val.Value;
                    count++;
                }
            }

            if (count == 0)
            {
                return null;
            }

            double average = sum / count;
            return Math.Round(average, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            double?[] values = { 10.5, null, 20.25, 30.75, null, 15.0 };

            double? avg = ComputeAverage(values);

            if (avg.HasValue)
            {
                Console.WriteLine("Average: " + avg.Value);
            }
            else
            {
                Console.WriteLine("Average: null");
            }
        }
    }
}
