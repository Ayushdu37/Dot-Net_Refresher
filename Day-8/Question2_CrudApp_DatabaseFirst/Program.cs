using System;
using System.Linq;
using Question2_CrudApp_DatabaseFirst.Data;
using Question2_CrudApp_DatabaseFirst.Models;

namespace Question2_CrudApp_DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new AppDbContext();

            // 1. CREATE
            Console.WriteLine("--- 1. CREATE ---");
            Student s1 = new Student { FirstName = "John", LastName = "Doe", Cgpa = 3.75m };
            Student s2 = new Student { FirstName = "Jane", LastName = "Smith", Cgpa = 3.90m };
            context.Students.AddRange(s1, s2);
            context.SaveChanges();
            Console.WriteLine($"Added students: {s1.FirstName} (Id: {s1.Id}), {s2.FirstName} (Id: {s2.Id})");

            // 2. READ (ALL)
            Console.WriteLine("\n--- 2. READ ALL ---");
            var allStudents = context.Students.ToList();
            foreach (var s in allStudents)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.FirstName} {s.LastName}, CGPA: {s.Cgpa}");
            }

            // 3. READ (BY ID)
            Console.WriteLine("\n--- 3. READ BY ID ---");
            var student = context.Students.Find(1);
            if (student != null)
            {
                Console.WriteLine($"Found: {student.FirstName} {student.LastName} with CGPA {student.Cgpa}");
            }

            // 4. UPDATE
            Console.WriteLine("\n--- 4. UPDATE ---");
            if (student != null)
            {
                student.Cgpa = 3.95m;
                context.SaveChanges();
                Console.WriteLine($"Updated {student.FirstName}'s CGPA to {student.Cgpa}");
            }

            // 5. DELETE
            Console.WriteLine("\n--- 5. DELETE ---");
            var toDelete = context.Students.Find(2);
            if (toDelete != null)
            {
                context.Students.Remove(toDelete);
                context.SaveChanges();
                Console.WriteLine($"Deleted Student ID: {toDelete.Id}");
            }

            // Final check
            Console.WriteLine("\n--- FINAL RECORDS ---");
            foreach (var s in context.Students.ToList())
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.FirstName} {s.LastName}, CGPA: {s.Cgpa}");
            }
        }
    }
}
