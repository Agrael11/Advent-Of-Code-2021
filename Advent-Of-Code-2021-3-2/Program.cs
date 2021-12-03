using System;
using System.IO;

namespace AdventOfCode.Day3.Puzzle2
{
    /// <summary>
    /// Main Class for Day 3 - Challange 2 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file and splits them by line
            List<string> inputData = new();
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().TrimEnd('\n').Split('\n').ToList();
            }

            //Initialize oxygen and CO2 rating values to 0
            int oxygenRating = 0;
            int CO2rating = 0;

            //Makes a copy of input values, so I can remove them without loosing original values
            List<string> removableList = new(inputData);

            //Go trough every position in the number of every number, if bit on that position is most common
            //or is contained in equal number of items in the list, keep the number, otherwise remove it.
            //Last  number left is Oxygen Rating
            for (int i = 0; i < inputData[0].Length; i++)
            {
                char mostCommon = GetMostCommonBit(i, ref removableList);
                for (int j = removableList.Count - 1; j >= 0; j--)
                {
                    if (removableList[j][i] != mostCommon) removableList.RemoveAt(j);
                }
                if (removableList.Count == 1)
                {
                    oxygenRating = Convert.ToInt32(removableList[0], 2);
                    break;
                }
            }

            //Refill the list
            removableList = new(inputData);

            //Go trough every position in the number of every number, if bit on that position is least common
            //of the items in the list, keep the number, otherwise remove it.
            //Last  number left is CO2 Rating
            for (int i = 0; i < inputData[0].Length; i++)
            {
                char mostCommon = GetMostCommonBit(i, ref removableList);
                for (int j = removableList.Count - 1; j >= 0; j--)
                {
                    if (removableList[j][i] == mostCommon) removableList.RemoveAt(j);
                }
                if (removableList.Count == 1)
                {
                    CO2rating = Convert.ToInt32(removableList[0], 2);
                    break;
                }
            }

            //Write the results
            Console.WriteLine($"Oxygen Ratings is {oxygenRating} and CO2 Rating is {CO2rating}");
            Console.WriteLine($"Life Support Rating it is {oxygenRating * CO2rating}");
        }

        /// <summary>
        /// Gets the most common bit on the position in the list
        /// To do that it searches all numbers in the list, and increments the counter every time it founds 1,
        /// If there is more 0 than there is 1s, return '0', otherwise it will return '1'.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static char GetMostCommonBit(int index, ref List<string> inputData)
        {
            int ones = 0;
            for (int i = 0; i < inputData.Count; i++)
            {
                if (inputData[i][index] == '1') ones++;
            }
            if (inputData.Count - ones > ones) return '0';
            return '1';
        }
    }
}