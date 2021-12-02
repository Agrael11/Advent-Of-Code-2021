using System;
using System.IO;

namespace AdventOfCode.Day1.Puzzle1
{
    /// <summary>
    /// Main Class for Day 1 - Challange 1 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file and splits them by line
            string[] inputData;
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().TrimEnd('\n').Split('\n');
            }
            
            //Defines Previous Number as first number in the list, and counter of increased items.
            int prevNumber = int.Parse(inputData[0]);
            int increaseCount = 0;

            //Goes trough every line of input, starting at second element (since first one is already parsed as prevNumber)
            //If current line is larger than previous line, increment the counter.
            for (int i = 1; i < inputData.Length; i++)
            {
                int number = int.Parse(inputData[i]);

                Console.Write($"{prevNumber}->{number}: ");

                if (number > prevNumber)
                {
                    Console.WriteLine("(Increased)");
                    increaseCount++;
                }
                else
                {
                    Console.WriteLine("(Decreased or equal)");
                }

                prevNumber = number;
            }

            //At the end write a number of increased inputs.
            Console.WriteLine(increaseCount);
        }
    }
}