using System;

namespace Question7_LuckyNumbers
{
    internal class Program
    {
        static bool IsPrime(long n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;
            if (n % 2 == 0 || n % 3 == 0) return false;
            for (long i = 5; i * i <= n; i += 6)
            {
                if (n % i == 0 || n % (i + 2) == 0) return false;
            }
            return true;
        }

        static long SumOfDigits(long n)
        {
            long sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            return sum;
        }

        static bool IsLuckyNumber(long x)
        {
            if (IsPrime(x)) return false;

            long sx = SumOfDigits(x);
            long sxSquared = SumOfDigits(x * x);

            return sxSquared == (sx * sx);
        }

        static int CountLuckyNumbers(long m, long n)
        {
            int count = 0;
            for (long i = m; i <= n; i++)
            {
                if (IsLuckyNumber(i))
                {
                    count++;
                }
            }
            return count;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter m and n (space separated): ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] parts = input.Split(' ');
                long m = Convert.ToInt64(parts[0]);
                long n = Convert.ToInt64(parts[1]);

                int result = CountLuckyNumbers(m, n);
                Console.WriteLine("Lucky Numbers Count: " + result);
            }
        }
    }
}
