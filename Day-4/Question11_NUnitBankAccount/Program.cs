using System;
using NUnit.Framework;

namespace Question11_NUnitBankAccount
{
    public class Program
    {
        public decimal Balance { get; private set; }

        public Program(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }
            Balance -= amount;
        }

        static void Main(string[] args)
        {
            Program account = new Program(1000m);
            Console.WriteLine("Initial Balance: " + account.Balance);

            account.Deposit(500m);
            Console.WriteLine("After Deposit: " + account.Balance);

            account.Withdraw(300m);
            Console.WriteLine("After Withdraw: " + account.Balance);
        }
    }

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            Program account = new Program(100m);
            account.Deposit(50m);
            Assert.AreEqual(150m, account.Balance);
        }

        [Test]
        public void Deposit_NegativeAmount_ThrowsException()
        {
            Program account = new Program(100m);
            var ex = Assert.Throws<ArgumentException>(() => account.Deposit(-50m));
            Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            Program account = new Program(100m);
            account.Withdraw(40m);
            Assert.AreEqual(60m, account.Balance);
        }

        [Test]
        public void Withdraw_AmountGreaterThanBalance_ThrowsException()
        {
            Program account = new Program(100m);
            var ex = Assert.Throws<InvalidOperationException>(() => account.Withdraw(150m));
            Assert.AreEqual("Insufficient funds.", ex.Message);
        }
    }
}
