using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Question8_LibraryManagement
{
    internal class Program
    {
        static List<dynamic> books = new List<dynamic>();

        static dynamic CreateBook(int id, string title, string author, string publisher, double price)
        {
            dynamic book = new ExpandoObject();
            book.Id = id;
            book.Title = title;
            book.Author = author;
            book.Publisher = publisher;
            book.Price = price;
            return book;
        }

        static void DisplayBook(dynamic book)
        {
            Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, Publisher: {book.Publisher}, Price: {book.Price}");
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter Book ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Title: ");
                    string title = Console.ReadLine() ?? "";
                    Console.Write("Enter Author: ");
                    string author = Console.ReadLine() ?? "";
                    Console.Write("Enter Publisher: ");
                    string publisher = Console.ReadLine() ?? "";
                    Console.Write("Enter Price: ");
                    double price = Convert.ToDouble(Console.ReadLine());

                    books.Add(CreateBook(id, title, author, publisher, price));
                    Console.WriteLine("Book added successfully!");
                }
                else if (choice == "2")
                {
                    Console.Write("Enter Book ID to update: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    dynamic? book = books.FirstOrDefault(b => b.Id == id);
                    if (book != null)
                    {
                        Console.Write("Enter New Title: ");
                        book.Title = Console.ReadLine() ?? "";
                        Console.Write("Enter New Author: ");
                        book.Author = Console.ReadLine() ?? "";
                        Console.Write("Enter New Publisher: ");
                        book.Publisher = Console.ReadLine() ?? "";
                        Console.Write("Enter New Price: ");
                        book.Price = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Book updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found!");
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter Book ID to delete: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    dynamic? book = books.FirstOrDefault(b => b.Id == id);
                    if (book != null)
                    {
                        books.Remove(book);
                        Console.WriteLine("Book deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Book not found!");
                    }
                }
                else if (choice == "4")
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books available.");
                    }
                    else
                    {
                        foreach (var book in books)
                        {
                            DisplayBook(book);
                        }
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- User Menu ---");
                Console.WriteLine("1. Browse All Books");
                Console.WriteLine("2. Search Book by Name");
                Console.WriteLine("3. Search Book by Publisher");
                Console.WriteLine("4. View Highest Priced Book");
                Console.WriteLine("5. View Lowest Priced Book");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books available.");
                    }
                    else
                    {
                        foreach (var book in books)
                        {
                            DisplayBook(book);
                        }
                    }
                }
                else if (choice == "2")
                {
                    Console.Write("Enter Book Name: ");
                    string name = Console.ReadLine() ?? "";
                    var found = books.Where(b => ((string)b.Title).IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    if (found.Count == 0)
                    {
                        Console.WriteLine("No matching books found.");
                    }
                    else
                    {
                        foreach (var book in found)
                        {
                            DisplayBook(book);
                        }
                    }
                }
                else if (choice == "3")
                {
                    Console.Write("Enter Publisher Name: ");
                    string pub = Console.ReadLine() ?? "";
                    var found = books.Where(b => ((string)b.Publisher).IndexOf(pub, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                    if (found.Count == 0)
                    {
                        Console.WriteLine("No matching books found.");
                    }
                    else
                    {
                        foreach (var book in found)
                        {
                            DisplayBook(book);
                        }
                    }
                }
                else if (choice == "4")
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books available.");
                    }
                    else
                    {
                        dynamic highest = books.OrderByDescending(b => (double)b.Price).First();
                        Console.WriteLine("Highest Priced Book:");
                        DisplayBook(highest);
                    }
                }
                else if (choice == "5")
                {
                    if (books.Count == 0)
                    {
                        Console.WriteLine("No books available.");
                    }
                    else
                    {
                        dynamic lowest = books.OrderBy(b => (double)b.Price).First();
                        Console.WriteLine("Lowest Priced Book:");
                        DisplayBook(lowest);
                    }
                }
                else if (choice == "6")
                {
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            books.Add(CreateBook(101, "C# Fundamentals", "John Doe", "TechPress", 450.0));
            books.Add(CreateBook(102, "Data Structures", "Jane Smith", "Oxford", 600.0));
            books.Add(CreateBook(103, "Clean Code", "Robert Martin", "Pearson", 750.0));

            while (true)
            {
                Console.WriteLine("\n=== Book Library Management System ===");
                Console.WriteLine("1. Admin Mode");
                Console.WriteLine("2. User Mode");
                Console.WriteLine("3. Exit");
                Console.Write("Select Mode: ");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    AdminMenu();
                }
                else if (choice == "2")
                {
                    UserMenu();
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }
    }
}
