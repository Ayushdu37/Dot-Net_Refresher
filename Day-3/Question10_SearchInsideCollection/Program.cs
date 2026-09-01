using System;
using System.Collections.Generic;
using System.Linq;

namespace Question10_SearchInsideCollection
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
            Program program = new Program();

            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine() ?? "";
                long soldCount = Convert.ToInt64(Console.ReadLine());
                itemDetails[name] = soldCount;
            }

            long searchCount = Convert.ToInt64(Console.ReadLine());

            var found = program.FindItemDetails(searchCount);

            Console.WriteLine("Item Details:");
            if (found.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                foreach (var kvp in found)
                {
                    Console.WriteLine($"{kvp.Key} : {kvp.Value}");
                }
            }

            var minMax = program.FindMinandMaxSoldItems();
            if (minMax.Count >= 2)
            {
                Console.WriteLine("Minimum Sold Item: " + minMax[0]);
                Console.WriteLine("Maximum Sold Item: " + minMax[1]);
            }

            Console.WriteLine("Items Sorted by Sold Count:");
            var sorted = program.SortByCount();
            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key} : {kvp.Value}");
            }
        }
    }
}
