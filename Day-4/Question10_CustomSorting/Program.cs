using System;
using System.Collections.Generic;

namespace Question10_CustomSorting
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int Marks { get; set; }

        public Student(string name, int age, int marks)
        {
            Name = name;
            Age = age;
            Marks = marks;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Marks: {Marks}";
        }
    }

    public class StudentComparer : IComparer<Student>
    {
        public int Compare(Student? x, Student? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int marksComparison = y.Marks.CompareTo(x.Marks);
            if (marksComparison != 0)
            {
                return marksComparison;
            }

            return x.Age.CompareTo(y.Age);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Alice", 20, 85),
                new Student("Bob", 22, 90),
                new Student("Charlie", 19, 85),
                new Student("David", 21, 90),
                new Student("Eve", 20, 78)
            };

            students.Sort(new StudentComparer());

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
