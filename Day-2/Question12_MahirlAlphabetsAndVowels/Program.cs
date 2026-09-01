using System;
using System.Collections.Generic;
using System.Text;

namespace Question12_MahirlAlphabetsAndVowels
{
    internal class Program
    {
        static bool IsVowel(char c)
        {
            char lower = char.ToLower(c);
            return lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u';
        }

        static bool IsConsonant(char c)
        {
            return char.IsLetter(c) && !IsVowel(c);
        }

        static string ProcessWords(string word1, string word2)
        {
            HashSet<char> word2Consonants = new HashSet<char>();
            foreach (char c in word2)
            {
                if (IsConsonant(c))
                {
                    word2Consonants.Add(char.ToLower(c));
                }
            }

            StringBuilder sb1 = new StringBuilder();
            foreach (char c in word1)
            {
                if (IsConsonant(c) && word2Consonants.Contains(char.ToLower(c)))
                {
                    continue;
                }
                sb1.Append(c);
            }

            string intermediate = sb1.ToString();
            if (string.IsNullOrEmpty(intermediate))
            {
                return "";
            }

            StringBuilder result = new StringBuilder();
            result.Append(intermediate[0]);

            for (int i = 1; i < intermediate.Length; i++)
            {
                if (char.ToLower(intermediate[i]) != char.ToLower(intermediate[i - 1]))
                {
                    result.Append(intermediate[i]);
                }
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter first word: ");
            string word1 = Console.ReadLine() ?? "";

            Console.Write("Enter second word: ");
            string word2 = Console.ReadLine() ?? "";

            string result = ProcessWords(word1, word2);
            Console.WriteLine(result);
        }
    }
}
