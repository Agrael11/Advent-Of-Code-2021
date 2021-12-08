using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day8.Puzzle1
{
    /// <summary>
    /// Main Class for Day 8 - Challange 1 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file and splits them by line
            List<string> inputData = new();
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n').ToList();
            }

            //Check numbers in output part (after " | ") of every input line. If number is 2 (2 long), 4 (4 long), 7 (3 long), or 8 (7 long) increment total counter
            int total = 0;
            foreach (string input in inputData)
            {
                string outputInfo = input.Split(" | ")[1];
                foreach (string outputNumeral in outputInfo.Split(' '))
                {
                    if (outputNumeral.Length == 2 || outputNumeral.Length == 3 || outputNumeral.Length == 4 || outputNumeral.Length == 7)
                        total++;
                }
            }

            //Write result
            Console.WriteLine(total);
        }
    }
}