using System;

namespace Question6_HeightCategory
{
    internal class Program
    {
        static string GetHeightCategory(int heightCm)
        {
            if (heightCm < 150)
            {
                return "Short";
            }
            else if (heightCm < 180)
            {
                return "Average";
            }
            else
            {
                return "Tall";
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter height in cm: ");
            int height = Convert.ToInt32(Console.ReadLine());

            string category = GetHeightCategory(height);
            Console.WriteLine("Category: " + category);
        }
    }
}
