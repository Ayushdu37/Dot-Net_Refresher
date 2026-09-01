using System;
using System.Globalization;
using System.Text;

namespace Question14_InventoryNameCleanup
{
    internal class Program
    {
        static string CleanupInventoryName(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                if (char.ToLower(input[i]) != char.ToLower(input[i - 1]))
                {
                    sb.Append(input[i]);
                }
            }

            string[] words = sb.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string joined = string.Join(" ", words);

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(joined.ToLower());
        }

        static void Main(string[] args)
        {
            string input = " llapppptop bag ";

            string output = CleanupInventoryName(input);

            Console.WriteLine(output);
        }
    }
}
