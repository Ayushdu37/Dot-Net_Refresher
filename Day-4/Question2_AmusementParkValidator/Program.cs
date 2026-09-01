using System;

namespace Question2_AmusementParkValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter weight: ");
            double weight = Convert.ToDouble(Console.ReadLine());

            if (age >= 18 && weight < 90)
            {
                Console.WriteLine("You are allowed to go for Ride");
            }
            else
            {
                Console.WriteLine("You are not allowed to go for Ride");
            }
        }
    }
}
