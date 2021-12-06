using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day6.Puzzle2
{
    /// <summary>
    /// Main Class for Day 6 - Challange 2 of Advent of Code 2021
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
            List<long> jellyfish = new List<long>();
            for (int i = 0; i <= 9; i++)
            {
                jellyfish.Add(0);
            }
            for (int i = 0; i < inputData.Count; i++)
            {
                foreach (string fish in inputData[i].Split(','))
                {
                    jellyfish[int.Parse(fish)]++;
                }
            }

            //simulate 80 days
            for (int day = 0; day < 256; day++)
            {
                //store jellyfish waiting to reset
                jellyfish[9] = jellyfish[0];
                //move jellyfish one day closer
                for (int dayBorn = 1; dayBorn < 9; dayBorn++)
                {
                    jellyfish[dayBorn - 1] = jellyfish[dayBorn];
                }
                //reset the jellyfish waiting
                jellyfish[6] += jellyfish[9];
                //add new jellyfish
                jellyfish[8] = jellyfish[9];
            }

            long realCount = 0;
            for (int i = 0; i < jellyfish.Count - 1; i++)
            {
                realCount+=jellyfish[i];
            }
            Console.WriteLine(realCount);
        }
    }
}