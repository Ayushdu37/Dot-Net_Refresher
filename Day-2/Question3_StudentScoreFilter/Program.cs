using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Question3_StudentScoreFilter
{
    record Student(string Name, int Score);

    internal class Program
    {
        static string FilterAndSerializeStudents(string[] items, int minScore)
        {
            List<Student> students = new List<Student>();

            foreach (string item in items)
            {
                string[] parts = item.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    students.Add(new Student(parts[0], score));
                }
            }

            var filteredStudents = students
                .Where(s => s.Score >= minScore)
                .OrderByDescending(s => s.Score)
                .ThenBy(s => s.Name, StringComparer.Ordinal)
                .ToList();

            return JsonSerializer.Serialize(filteredStudents);
        }

        static void Main(string[] args)
        {
            string[] items = { "Alice:85", "Bob:72", "Charlie:85", "David:60", "Eve:95" };
            int minScore = 75;

            string json = FilterAndSerializeStudents(items, minScore);

            Console.WriteLine(json);
        }
    }
}
