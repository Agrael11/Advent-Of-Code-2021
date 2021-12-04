using System;
using System.IO;

namespace AdventOfCode.Day1.Puzzle2
{
    /// <summary>
    /// Main Class for Day 1 - Challange 2 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file and splits them by line
            string[] inputData;
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n');
            }

            //Defines Previous Sum as Sum of first three element on the list, and counter of increased sums.
            int prevSum = GetSum(0, ref inputData);
            int increaseCount = 0;

            //Goes trough every line of input, starting at second element (since first one is already parsed as prevNumber), excluding last 2 elements
            //If sum at the current index is larger than sum at last one, increment the counter.
            for (int i = 1; i < inputData.Length - 2; i++)
            {
                int number = GetSum(i, ref inputData);

                Console.Write($"{prevSum}->{GetSumText(i, ref inputData)} = {number}: ");

                if (number > prevSum)
                {
                    Console.WriteLine("(Increased)");
                    increaseCount++;
                }
                else
                {
                    Console.WriteLine("(Decreased or equal)");
                }
                prevSum = number;
            }

            //At the end write a number of increased sums.
            Console.WriteLine(increaseCount);
        }

        /// <summary>
        /// Gets sum of three elements in list, starting at index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static int GetSum(int index, ref string[] inputData)
        {
            return int.Parse(inputData[index]) + int.Parse(inputData[index + 1]) + int.Parse(inputData[index + 2]);
        }

        /// <summary>
        /// Makes string representing addition of three elements in list, starting at index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static string GetSumText(int index, ref string[] inputData)
        {
            return $"{inputData[index]} + {inputData[index + 1]} + {inputData[index + 2]}";
        }
    }
}