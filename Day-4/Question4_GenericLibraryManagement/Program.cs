using System;
using System.Collections.Generic;

namespace Question4_GenericLibraryManagement
{
    public class AcademicBook
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;

        public AcademicBook(int bookId, string title, string subject)
        {
            BookId = bookId;
            Title = title;
            Subject = subject;
        }
    }

    public class DigitalBook
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public double FileSizeMB { get; set; }

        public DigitalBook(int bookId, string title, double fileSizeMB)
        {
            BookId = bookId;
            Title = title;
            FileSizeMB = fileSizeMB;
        }
    }

    public class Library<T>
    {
        private List<T> books = new List<T>();

        public void Add(T book)
        {
            books.Add(book);
        }

        public List<T> GetAll()
        {
            return books;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            AcademicBook academicBook = new AcademicBook(1001, "Data Structures", "Computer Science");
            DigitalBook digitalBook = new DigitalBook(2001, "AI Basics", 15.5);

            Library<AcademicBook> academicLibrary = new Library<AcademicBook>();
            Library<DigitalBook> digitalLibrary = new Library<DigitalBook>();

            academicLibrary.Add(academicBook);
            digitalLibrary.Add(digitalBook);

            Console.WriteLine("========= ACADEMIC BOOKS =========");
            foreach (var book in academicLibrary.GetAll())
            {
                Console.WriteLine($"{book.BookId} - {book.Title} - {book.Subject}");
            }
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            Console.WriteLine("========= DIGITAL BOOKS =========");
            foreach (var book in digitalLibrary.GetAll())
            {
                Console.WriteLine($"{book.BookId} - {book.Title} - {book.FileSizeMB} MB");
            }
            Console.WriteLine("---------------------------------");
        }
    }
}
