using System;
using System.Collections.Generic;

class Program
{
    public static SortedDictionary<int, Bike> bikeDetails =
        new SortedDictionary<int, Bike>();

    static void Main(string[] args)
    {
        BikeUtility utility = new BikeUtility();

        while (true)
        {
            Console.WriteLine("1. Add Bike Details");
            Console.WriteLine("2. Group Bikes By Brand");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:

                    Console.Write("Enter the model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter the brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the price per day: ");
                    int price = int.Parse(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);

                    Console.WriteLine("Bike details added successfully");
                    break;

                case 2:

                    SortedDictionary<string, List<Bike>> result =
                        utility.GroupBikesByBrand();

                    foreach (KeyValuePair<string, List<Bike>> item in result)
                    {
                        foreach (Bike bike in item.Value)
                        {
                            Console.WriteLine(item.Key + " " + bike.Model);
                        }
                    }

                    break;

                case 3:

                    return;

                default:

                    Console.WriteLine("Invalid Choice");
                    break;
            }

            Console.WriteLine();
        }
    }
}