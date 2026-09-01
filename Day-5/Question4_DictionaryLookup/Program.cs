using System;
using System.Collections.Generic;

namespace Question4_DictionaryLookup
{
    internal class Program
    {
        static int GetTotalSalary(List<int> employeeIds, Dictionary<int, int> salaryMap)
        {
            int total = 0;

            foreach (int id in employeeIds)
            {
                if (salaryMap.TryGetValue(id, out int salary))
                {
                    total += salary;
                }
            }

            return total;
        }

        static void Main(string[] args)
        {
            List<int> ids = new List<int> { 1, 4, 5 };
            Dictionary<int, int> salaryMap = new Dictionary<int, int>
            {
                { 1, 20000 },
                { 4, 40000 },
                { 5, 15000 }
            };

            int totalSalary = GetTotalSalary(ids, salaryMap);
            Console.WriteLine(totalSalary);
        }
    }
}
