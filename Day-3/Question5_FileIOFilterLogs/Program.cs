using System;
using System.Collections.Generic;
using System.IO;

namespace Question5_FileIOFilterLogs
{
    internal class Program
    {
        static void FilterErrorLogs(string inputPath, string outputPath)
        {
            if (!File.Exists(inputPath))
            {
                File.WriteAllLines(inputPath, new string[]
                {
                    "INFO: System initialized",
                    "WARN: Memory usage high",
                    "ERROR: Database connection failed",
                    "INFO: User logged in",
                    "ERROR: NullReferenceException occurred"
                });
            }

            string[] lines = File.ReadAllLines(inputPath);
            List<string> errorLogs = new List<string>();

            foreach (string line in lines)
            {
                if (line.Contains("ERROR", StringComparison.OrdinalIgnoreCase))
                {
                    errorLogs.Add(line);
                }
            }

            File.WriteAllLines(outputPath, errorLogs);
            Console.WriteLine($"Extracted {errorLogs.Count} error logs to {outputPath}");
        }

        static void Main(string[] args)
        {
            string inputFile = "log.txt";
            string outputFile = "error.txt";

            FilterErrorLogs(inputFile, outputFile);
        }
    }
}
