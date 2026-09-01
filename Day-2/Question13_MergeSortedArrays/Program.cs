using System;

namespace Question13_MergeSortedArrays
{
    internal class Program
    {
        static T[] MergeSorted<T>(T[] a, T[] b) where T : IComparable<T>
        {
            int n = a.Length;
            int m = b.Length;
            T[] merged = new T[n + m];

            int i = 0, j = 0, k = 0;

            while (i < n && j < m)
            {
                if (a[i].CompareTo(b[j]) <= 0)
                {
                    merged[k++] = a[i++];
                }
                else
                {
                    merged[k++] = b[j++];
                }
            }

            while (i < n)
            {
                merged[k++] = a[i++];
            }

            while (j < m)
            {
                merged[k++] = b[j++];
            }

            return merged;
        }

        static void Main(string[] args)
        {
            int[] a = { 1, 3, 5, 7 };
            int[] b = { 2, 4, 6, 8, 10 };

            int[] merged = MergeSorted(a, b);

            Console.WriteLine("[" + string.Join(", ", merged) + "]");
        }
    }
}
