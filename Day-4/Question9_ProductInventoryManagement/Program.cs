using System;
using System.Collections.Generic;
using System.Linq;

namespace Question9_ProductInventoryManagement
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(int productId, string name, double price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }

    public class InventoryEngine
    {
        public void DisplayReport(List<Product> products)
        {
            Console.WriteLine("Low Stock Products:");
            products
                .Where(p => p.Quantity < 10)
                .ToList()
                .ForEach(p => Console.WriteLine(p.Name));

            Console.WriteLine("\nProducts Sorted by Price:");
            products
                .OrderBy(p => p.Price)
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} - {p.Price}"));

            double totalValue = products.Sum(p => p.Price * p.Quantity);
            Console.WriteLine($"\nTotal Inventory Value:\nRs {totalValue}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product(201, "Laptop", 60000, 5),
                new Product(202, "Mouse", 800, 25),
                new Product(203, "Keyboard", 1500, 8),
                new Product(204, "Monitor", 12000, 12)
            };

            InventoryEngine engine = new InventoryEngine();
            engine.DisplayReport(products);
        }
    }
}
