using System;
using System.Collections.Generic;

namespace Question7_BankingSystemExceptionHandling
{
    public class BankAccount
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string HolderName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsFrozen { get; set; }
        public decimal DailyWithdrawn { get; set; }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class InvalidAccountException : Exception
    {
        public InvalidAccountException(string message) : base(message) { }
    }

    public class DailyLimitExceededException : Exception
    {
        public DailyLimitExceededException(string message) : base(message) { }
    }

    public class AccountFrozenException : Exception
    {
        public AccountFrozenException(string message) : base(message) { }
    }

    public class NetworkException : Exception
    {
        public NetworkException(string message) : base(message) { }
    }

    public class TransactionService
    {
        private Dictionary<string, BankAccount> accounts;
        public List<string> TransactionLogs { get; } = new List<string>();
        public bool SimulateNetworkFailure { get; set; } = false;

        public TransactionService(Dictionary<string, BankAccount> accounts)
        {
            this.accounts = accounts;
        }

        public void Withdraw(string accountNo, decimal amount)
        {
            if (SimulateNetworkFailure)
            {
                TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Failed (Network)");
                throw new NetworkException("Unable to connect to banking server.");
            }

            if (!accounts.ContainsKey(accountNo))
            {
                TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Failed (Invalid Account)");
                throw new InvalidAccountException($"Account {accountNo} not found.");
            }

            BankAccount account = accounts[accountNo];

            if (account.IsFrozen)
            {
                TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Failed (Frozen Account)");
                throw new AccountFrozenException("Account is currently frozen.");
            }

            if (account.DailyWithdrawn + amount > 50000)
            {
                TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Failed (Daily Limit Exceeded)");
                throw new DailyLimitExceededException("Daily withdrawal limit exceeded.");
            }

            if (account.Balance < amount)
            {
                TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Failed (Insufficient Funds)");
                throw new InsufficientFundsException("Insufficient funds.");
            }

            account.Balance -= amount;
            account.DailyWithdrawn += amount;
            TransactionLogs.Add($"Withdraw ₹{amount} from {accountNo} - Success");
            Console.WriteLine("Transaction Successful");
            Console.WriteLine($"Remaining Balance: {account.Balance}");
        }

        public void Deposit(string accountNo, decimal amount)
        {
            if (!accounts.ContainsKey(accountNo))
            {
                throw new InvalidAccountException($"Account {accountNo} not found.");
            }

            BankAccount account = accounts[accountNo];
            if (account.IsFrozen)
            {
                throw new AccountFrozenException("Account is currently frozen.");
            }

            account.Balance += amount;
            TransactionLogs.Add($"Deposit ₹{amount} to {accountNo} - Success");
            Console.WriteLine("Deposit Successful");
            Console.WriteLine($"Remaining Balance: {account.Balance}");
        }

        public void Transfer(string fromAccount, string toAccount, decimal amount)
        {
            Withdraw(fromAccount, amount);
            Deposit(toAccount, amount);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>()
            {
                {
                    "ACC1001",
                    new BankAccount
                    {
                        AccountNumber = "ACC1001",
                        HolderName = "Pankaj",
                        Balance = 25000,
                        IsFrozen = false,
                        DailyWithdrawn = 10000
                    }
                },
                {
                    "ACC1002",
                    new BankAccount
                    {
                        AccountNumber = "ACC1002",
                        HolderName = "Rahul",
                        Balance = 100000,
                        IsFrozen = true,
                        DailyWithdrawn = 0
                    }
                }
            };

            TransactionService service = new TransactionService(accounts);

            Console.WriteLine("--- Task 1 ---");
            try
            {
                service.Withdraw("ACC1001", 5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }

            Console.WriteLine("\n--- Task 2 ---");
            try
            {
                service.Withdraw("ACC1001", 30000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }

            Console.WriteLine("\n--- Task 3 ---");
            try
            {
                service.Withdraw("ACC1001", 45000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }

            Console.WriteLine("\n--- Task 4 ---");
            try
            {
                service.Withdraw("ACC9999", 5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }

            Console.WriteLine("\n--- Task 5 ---");
            try
            {
                service.Withdraw("ACC1002", 5000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }

            Console.WriteLine("\n--- Task 6 ---");
            try
            {
                service.SimulateNetworkFailure = true;
                service.Withdraw("ACC1001", 1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
        }
    }
}
