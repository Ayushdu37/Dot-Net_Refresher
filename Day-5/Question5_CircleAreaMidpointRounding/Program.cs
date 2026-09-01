using System;

namespace Question5_CircleAreaMidpointRounding
{
    internal class Program
    {
        static double CalculateCircleArea(double radius)
        {
            double area = Math.PI * radius * radius;
            return Math.Round(area, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter radius: ");
            double radius = Convert.ToDouble(Console.ReadLine());

            double area = CalculateCircleArea(radius);
            Console.WriteLine(area);
        }
    }
}
