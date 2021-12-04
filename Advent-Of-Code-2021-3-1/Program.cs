using System;
using System.IO;

namespace AdventOfCode.Day3.Puzzle1
{
    /// <summary>
    /// Main Class for Day 3 - Challange 1 of Advent of Code 2021
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

            //Initial definition of gammaRate (starting at 0)
            int gammaRate = 0;

            // Looking trough every position of every number in the list - most common number in bit position will get
            // that position in gammaRate - so if most common bit on first position is 0, the gammaRate will have 0 on
            // first position.
            for (int i = 0; i < inputData[0].Length; i++)
            {
                int mostCommon = GetMostCommonBit(i, ref inputData);
                Console.WriteLine($"Most Common at {i}({inputData[0].Length-1-i}) is {mostCommon} which corresponds to number {(int)Math.Pow(2, inputData[0].Length-1-i)}");
                gammaRate += mostCommon * (int)Math.Pow(2, inputData[0].Length- 1 - i);
            }

            // Epsilon Rate is essentailly reversed gamma rate, so I just reverse all bits in it.
            int epsilonRate = (int)Math.Pow(2, inputData[0].Length) - 1 - gammaRate;
            Console.WriteLine();

            //And write the result
            Console.WriteLine($"Epsilon Rate is : {epsilonRate}({Convert.ToString(epsilonRate,2)}); Gamma Rate is {gammaRate}({Convert.ToString(gammaRate, 2)})");
            Console.WriteLine($"Power Consumption is : {epsilonRate * gammaRate}");
        }

        /// <summary>
        /// Gets the most common bit on the position in the list
        /// To do that it searches all numbers in the list, and increments the counter every time it founds 1,
        /// If there is more 0 than is 1s, return 1, otherwise it will return 1.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static int GetMostCommonBit(int index, ref string[] inputData)
        {
            int ones = 0;
            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i][index] == '1') ones++;
            }
            if (inputData.Length - ones > ones) return 0;
            return 1;
        }
    }
}