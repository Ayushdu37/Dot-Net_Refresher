using System;

namespace Question4_GreatestCommonDivisor
{
    internal class Program
    {
        static long ComputeGcd(long a, long b)
        {
            if (b == 0)
            {
                return a;
            }

            return ComputeGcd(b, a % b);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            long a = Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter b: ");
            long b = Convert.ToInt64(Console.ReadLine());

            long gcd = ComputeGcd(a, b);
            Console.WriteLine("GCD: " + gcd);
        }
    }
}
