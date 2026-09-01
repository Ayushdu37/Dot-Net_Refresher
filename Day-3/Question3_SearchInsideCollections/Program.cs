using System;
using System.Collections.Generic;
using System.Linq;

namespace Question3_SearchInsideCollections
{
    public class Program
    {
        public static SortedDictionary<string, long> itemDetails = new SortedDictionary<string, long>();

        public SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new SortedDictionary<string, long>();

            foreach (var kvp in itemDetails)
            {
                if (kvp.Value == soldCount)
                {
                    result.Add(kvp.Key, kvp.Value);
                }
            }

            return result;
        }

        public List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new List<string>();

            if (itemDetails.Count == 0)
            {
                return result;
            }

            long minVal = itemDetails.Values.Min();
            long maxVal = itemDetails.Values.Max();

            string minItem = itemDetails.First(kvp => kvp.Value == minVal).Key;
            string maxItem = itemDetails.First(kvp => kvp.Value == maxVal).Key;

            result.Add(minItem);
            result.Add(maxItem);

            return result;
        }

        public Dictionary<string, long> SortByCount()
        {
            return itemDetails
                .OrderBy(kvp => kvp.Value)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            Console.Write("Enter number of items: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter item name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Enter sold count: ");
                long count = Convert.ToInt64(Console.ReadLine());

                itemDetails[name] = count;
            }

            Console.Write("Enter sold count to search: ");
            long searchCount = Convert.ToInt64(Console.ReadLine());

            var foundItems = p.FindItemDetails(searchCount);
            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                foreach (var kvp in foundItems)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }
            }

            var minMax = p.FindMinandMaxSoldItems();
            if (minMax.Count >= 2)
            {
                Console.WriteLine("Minimum sold item: " + minMax[0]);
                Console.WriteLine("Maximum sold item: " + minMax[1]);
            }

            Console.WriteLine("Sorted by count:");
            var sorted = p.SortByCount();
            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}
