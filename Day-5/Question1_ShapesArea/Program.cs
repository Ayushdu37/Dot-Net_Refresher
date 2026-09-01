using System;
using System.Collections.Generic;

namespace Question1_ShapesArea
{
    public interface IArea
    {
        double GetArea();
    }

    public abstract class Shape : IArea
    {
        public abstract double GetArea();
    }

    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width * height;
        }
    }

    public class Triangle : Shape
    {
        private double baseLength;
        private double height;

        public Triangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }

        public override double GetArea()
        {
            return 0.5 * baseLength * height;
        }
    }

    internal class Program
    {
        static double ComputeTotalArea(string[] shapes)
        {
            double totalArea = 0.0;

            foreach (string shapeStr in shapes)
            {
                if (string.IsNullOrWhiteSpace(shapeStr)) continue;

                string[] parts = shapeStr.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 0) continue;

                string type = parts[0].ToUpper();
                Shape? shape = null;

                if (type == "C" && parts.Length == 2)
                {
                    double r = Convert.ToDouble(parts[1]);
                    shape = new Circle(r);
                }
                else if (type == "R" && parts.Length == 3)
                {
                    double w = Convert.ToDouble(parts[1]);
                    double h = Convert.ToDouble(parts[2]);
                    shape = new Rectangle(w, h);
                }
                else if (type == "T" && parts.Length == 3)
                {
                    double b = Convert.ToDouble(parts[1]);
                    double h = Convert.ToDouble(parts[2]);
                    shape = new Triangle(b, h);
                }

                if (shape != null)
                {
                    totalArea += shape.GetArea();
                }
            }

            return Math.Round(totalArea, 2, MidpointRounding.AwayFromZero);
        }

        static void Main(string[] args)
        {
            string[] shapes = {
                "C 5",
                "R 4 6",
                "T 3 8"
            };

            double total = ComputeTotalArea(shapes);
            Console.WriteLine("Total Area: " + total);
        }
    }
}
