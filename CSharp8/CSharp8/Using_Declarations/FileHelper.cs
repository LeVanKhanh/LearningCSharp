using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp8.Using_Declarations
{
    public class FileHelper
    {
        public static int WriteLinesToFile(IEnumerable<string> lines, string fileName)
        {
            using var file = new System.IO.StreamWriter($"{fileName}.txt");
            // Notice how we declare skippedLines after the using statement.
            int skippedLines = 0;
            foreach (string line in lines)
            {
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
                else
                {
                    skippedLines++;
                }
            }
            // Notice how skippedLines is in scope here.
            return skippedLines;
            // file is disposed here
        }

        public static void ReadFile(string fileName)
        {
            using var file = new System.IO.StreamReader($"{fileName}.txt");
            while (!file.EndOfStream)
            {
                Console.WriteLine(file.ReadLine());
            }
        }

        public static void DeleteFile(string fileName)
        {
            File.Delete($"{fileName}.txt");
        }
    }
}
