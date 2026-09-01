using System;

namespace Question5_LargestOfThree
{
    internal class Program
    {
        static int FindLargest(int a, int b, int c)
        {
            if (a >= b && a >= c)
            {
                return a;
            }
            else if (b >= a && b >= c)
            {
                return b;
            }
            else
            {
                return c;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter b: ");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter c: ");
            int c = Convert.ToInt32(Console.ReadLine());

            int largest = FindLargest(a, b, c);
            Console.WriteLine("Largest: " + largest);
        }
    }
}
