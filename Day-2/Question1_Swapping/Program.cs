using System;

namespace Question1_Swapping
{
    internal class Program
    {
        // Method 1: Swap two numbers using ref without temp variable
        static void SwapUsingRef(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        // Method 2: Swap two numbers using out without temp variable
        static void SwapUsingOut(int a, int b, out int swappedA, out int swappedB)
        {
            swappedA = b;
            swappedB = a;
        }

        static void Main(string[] args)
        {
            // Input two numbers
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\nOriginal numbers: num1 = {num1}, num2 = {num2}");

            // 1. Swapping using ref
            int a = num1;
            int b = num2;
            SwapUsingRef(ref a, ref b);
            Console.WriteLine($"After swapping using ref: a = {a}, b = {b}");

            // 2. Swapping using out
            SwapUsingOut(num1, num2, out int outA, out int outB);
            Console.WriteLine($"After swapping using out: outA = {outA}, outB = {outB}");
        }
    }
}
