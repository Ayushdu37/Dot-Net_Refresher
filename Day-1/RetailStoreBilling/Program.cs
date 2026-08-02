using System;

Console.Write("Enter Item Price: ");
string priceInput = Console.ReadLine();

double price;

if (!double.TryParse(priceInput, out price))
{
    Console.WriteLine("Invalid Price");
    return;
}

if (price < 0)
{
    Console.WriteLine("Price cannot be negative");
    return;
}

Console.Write("Enter Quantity: ");
string quantityInput = Console.ReadLine();

int quantity;

if (!int.TryParse(quantityInput, out quantity))
{
    Console.WriteLine("Invalid Quantity");
    return;
}

if (quantity < 0)
{
    Console.WriteLine("Quantity cannot be negative");
    return;
}

Console.Write("Enter Discount Percentage: ");
string discountInput = Console.ReadLine();

double discount;

if (!double.TryParse(discountInput, out discount))
{
    Console.WriteLine("Invalid Discount");
    return;
}

if (discount < 0)
{
    Console.WriteLine("Discount cannot be negative");
    return;
}

double subtotal = price * quantity;
double discountAmount = subtotal * discount / 100;
double finalAmount = subtotal - discountAmount;

subtotal = Math.Round(subtotal, 2);
discountAmount = Math.Round(discountAmount, 2);
finalAmount = Math.Round(finalAmount, 2);

Console.WriteLine();
Console.WriteLine($"Subtotal: {subtotal}");
Console.WriteLine($"Discount Amount: {discountAmount}");
Console.WriteLine($"Final Payable Amount: {finalAmount}");