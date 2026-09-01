using System;

namespace Question9_RetailStoreCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter item price: ");
            string? priceInput = Console.ReadLine();
            if (!double.TryParse(priceInput, out double price) || price < 0)
            {
                Console.WriteLine("Invalid input: Price must be a non-negative number.");
                return;
            }

            Console.Write("Enter quantity: ");
            string? qtyInput = Console.ReadLine();
            if (!int.TryParse(qtyInput, out int quantity) || quantity < 0)
            {
                Console.WriteLine("Invalid input: Quantity must be a non-negative integer.");
                return;
            }

            Console.Write("Enter discount percentage: ");
            string? discInput = Console.ReadLine();
            if (!double.TryParse(discInput, out double discount) || discount < 0 || discount > 100)
            {
                Console.WriteLine("Invalid input: Discount must be between 0 and 100.");
                return;
            }

            double subtotal = Math.Round(price * quantity, 2);
            double discountAmount = Math.Round(subtotal * (discount / 100.0), 2);
            double finalPayable = Math.Round(subtotal - discountAmount, 2);

            Console.WriteLine($"Subtotal: {subtotal:F2}");
            Console.WriteLine($"Discount Amount: {discountAmount:F2}");
            Console.WriteLine($"Final Payable Amount: {finalPayable:F2}");
        }
    }
}
