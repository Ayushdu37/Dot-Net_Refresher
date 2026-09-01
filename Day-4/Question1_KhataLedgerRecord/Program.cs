using System;
using System.Collections.Generic;

namespace Question1_KhataLedgerRecord
{
    public class Khata
    {
        private Dictionary<string, int> records;

        public Khata(Dictionary<string, int> record)
        {
            this.records = record;
        }

        public int getTotal()
        {
            int total = 0;
            foreach (int amount in records.Values)
            {
                total += amount;
            }
            return total;
        }

        public int getRepeatAmount()
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();

            foreach (int amount in records.Values)
            {
                if (frequency.ContainsKey(amount))
                {
                    frequency[amount]++;
                }
                else
                {
                    frequency[amount] = 1;
                }
            }

            int repeatCount = 0;
            foreach (int count in frequency.Values)
            {
                if (count > 1)
                {
                    repeatCount++;
                }
            }

            return repeatCount;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> record = new Dictionary<string, int>
            {
                { "Milk", 100 },
                { "Tea", 50 },
                { "Coffee", 100 },
                { "Sugar", 50 },
                { "Salt", 200 }
            };

            Khata khata = new Khata(record);

            Console.WriteLine("Total Amount: " + khata.getTotal());
            Console.WriteLine("Repeated Amount Count: " + khata.getRepeatAmount());
        }
    }
}
