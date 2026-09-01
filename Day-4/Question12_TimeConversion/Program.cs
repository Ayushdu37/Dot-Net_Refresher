using System;

namespace Question12_TimeConversion
{
    internal class Program
    {
        static string ConvertSecondsToTime(int totalSeconds)
        {
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;

            return $"{minutes}:{seconds:D2}";
        }

        static void Main(string[] args)
        {
            Console.Write("Enter total seconds: ");
            int totalSeconds = Convert.ToInt32(Console.ReadLine());

            string result = ConvertSecondsToTime(totalSeconds);
            Console.WriteLine(result);
        }
    }
}
