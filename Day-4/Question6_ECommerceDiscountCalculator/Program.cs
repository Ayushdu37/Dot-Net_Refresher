using System;

namespace Question6_ECommerceDiscountCalculator
{
    internal class Program
    {
        static void CalculateAndDisplay(char customerTypeChar, double originalPrice)
        {
            string customerType;
            double discountPercentage = 0;

            switch (char.ToUpper(customerTypeChar))
            {
                case 'R':
                    customerType = "Regular";
                    if (originalPrice > 100)
                    {
                        discountPercentage = 5;
                    }
                    break;
                case 'P':
                    customerType = "Premium";
                    discountPercentage = 10;
                    break;
                case 'V':
                    customerType = "VIP";
                    if (originalPrice > 200)
                    {
                        discountPercentage = 20;
                    }
                    else
                    {
                        discountPercentage = 15;
                    }
                    break;
                default:
                    customerType = "Unknown";
                    discountPercentage = 0;
                    break;
            }

            double discountAmount = Math.Round(originalPrice * (discountPercentage / 100.0), 2);
            double finalPrice = Math.Round(originalPrice - discountAmount, 2);

            Console.WriteLine($"Customer Type: {customerType}");
            Console.WriteLine($"Original Price: ${originalPrice:F2}");
            Console.WriteLine($"Discount Applied: {discountPercentage} %");
            Console.WriteLine($"Discount Amount: ${discountAmount:F2}");
            Console.WriteLine($"Final Price: ${finalPrice:F2}");
            Console.WriteLine("------------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== E-COMMERCE DISCOUNT CALCULATOR ===\n");

            var sampleData = new (char type, double amount)[]
            {
                ('R', 150.00),
                ('R', 80.00),
                ('P', 120.00),
                ('V', 250.00),
                ('V', 180.00),
                ('R', 500.00)
            };

            foreach (var item in sampleData)
            {
                CalculateAndDisplay(item.type, item.amount);
            }
        }
    }
}
