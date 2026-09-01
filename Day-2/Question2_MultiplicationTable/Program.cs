using System;

namespace Question2_MultiplicationTable
{
    internal class Program
    {
        // Function to return multiplication table row
        static int[] GetMultiplicationTableRow(int n, int upto)
        {
            // Create an array of size upto
            int[] row = new int[upto];

            // Fill array with multiples of n from 1 to upto
            for (int i = 0; i < upto; i++)
            {
                row[i] = n * (i + 1);
            }

            return row;
        }

        static void Main(string[] args)
        {
            // Input number and upto value
            Console.Write("Enter n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter upto: ");
            int upto = Convert.ToInt32(Console.ReadLine());

            // Call function
            int[] result = GetMultiplicationTableRow(n, upto);

            // Display output
            Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
        }
    }
}
