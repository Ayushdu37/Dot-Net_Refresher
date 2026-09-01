using System;
using System.Collections.Generic;

namespace Question6_CustomDistinctByExtension
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> CustomDistinctBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
            {
                TKey key = keySelector(element);
                if (seenKeys.Add(key))
                {
                    yield return element;
                }
            }
        }
    }

    internal class Program
    {
        static string[] GetDistinctNames(string[] items)
        {
            List<(string id, string name)> parsedItems = new List<(string id, string name)>();

            foreach (string item in items)
            {
                string[] parts = item.Split(':');
                if (parts.Length == 2)
                {
                    parsedItems.Add((parts[0], parts[1]));
                }
            }

            var distinct = parsedItems.CustomDistinctBy(x => x.id);

            List<string> result = new List<string>();
            foreach (var item in distinct)
            {
                result.Add(item.name);
            }

            return result.ToArray();
        }

        static void Main(string[] args)
        {
            string[] items = {
                "1:Alice",
                "2:Bob",
                "1:Charlie",
                "3:David",
                "2:Eve"
            };

            string[] names = GetDistinctNames(items);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
