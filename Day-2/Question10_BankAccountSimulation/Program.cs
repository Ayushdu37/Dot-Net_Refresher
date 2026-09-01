using System;

namespace Question10_BankAccountSimulation
{
    internal class Program
    {
        static int SimulateBankAccount(int initialBalance, int[] transactions)
        {
            int balance = initialBalance;

            foreach (int transaction in transactions)
            {
                if (transaction >= 0)
                {
                    balance += transaction;
                }
                else
                {
                    if (balance + transaction >= 0)
                    {
                        balance += transaction;
                    }
                }
            }

            return balance;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter initial balance: ");
            int initialBalance = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter transactions separated by space: ");
            string? input = Console.ReadLine();

            int[] transactions = string.IsNullOrWhiteSpace(input)
                ? Array.Empty<int>()
                : Array.ConvertAll(input.Split(' '), int.Parse);

            int finalBalance = SimulateBankAccount(initialBalance, transactions);
            Console.WriteLine("Final Balance: " + finalBalance);
        }
    }
}
