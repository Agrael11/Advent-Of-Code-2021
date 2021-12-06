using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day6.Puzzle1
{
    /// <summary>
    /// Main Class for Day 6 - Challange 1 of Advent of Code 2021
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

            //Parse data into jellyfishes
            List<int> jellyfish = new();
            for (int i = 0; i < inputData.Count; i++)
            {
                foreach (string fish in inputData[i].Split(','))
                {
                    jellyfish.Add(int.Parse(fish));
                }
            }

            //simulate 80 days
            for (int day = 0; day < 80; day++)
            {
                //Store old jellyfish count
                int oldcount = jellyfish.Count;
                //One day
                for (int fishIndex = 0; fishIndex < oldcount; fishIndex++)
                {
                    if (jellyfish[fishIndex] == 0)
                    {
                        jellyfish[fishIndex] = 6;
                        jellyfish.Add(8);
                    }
                    else
                    {
                        jellyfish[fishIndex]--;
                    }
                }
            }

            Console.WriteLine(jellyfish.Count);
        }
    }
}