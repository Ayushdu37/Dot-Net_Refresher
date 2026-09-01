using System;

namespace Question4_ArithmeticExpressionEvaluator
{
    internal class Program
    {
        static string EvaluateExpression(string? expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                return "Error:InvalidExpression";
            }

            string[] parts = expression.Split(' ');
            if (parts.Length != 3)
            {
                return "Error:InvalidExpression";
            }

            bool isAValid = int.TryParse(parts[0], out int a);
            bool isBValid = int.TryParse(parts[2], out int b);

            if (!isAValid || !isBValid)
            {
                return "Error:InvalidNumber";
            }

            string op = parts[1];

            if (op != "+" && op != "-" && op != "*" && op != "/")
            {
                return "Error:UnknownOperator";
            }

            if (op == "/" && b == 0)
            {
                return "Error:DivideByZero";
            }

            return op switch
            {
                "+" => (a + b).ToString(),
                "-" => (a - b).ToString(),
                "*" => (a * b).ToString(),
                "/" => (a / b).ToString(),
                _ => "Error:UnknownOperator"
            };
        }

        static void Main(string[] args)
        {
            Console.Write("Enter expression: ");
            string? input = Console.ReadLine();

            string result = EvaluateExpression(input);
            Console.WriteLine(result);
        }
    }
}
