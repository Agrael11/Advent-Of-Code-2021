using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day7.Puzzle2
{
    /// <summary>
    /// Main Class for Day 7 - Challange 2 of Advent of Code 2021
    /// </summary>
    class Program
    {
        //Gets sum of sequence of numbers
        static int SumSequence(int input)
        {
            return (int)(input * ((input + 1) / 2.0f));
        }
         
        static void Main()
        {
            //Read input data from text file and splits them by line
            List<string> inputData = new();
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n').ToList();
            }

            //Parse data into crabmarines and get their biggest position
            List<int> crabMarines = new();
            int maxHorizontal = 0;
            foreach (string inputLine in inputData)
            {
                foreach (string inputNumber in inputLine.Split(','))
                {
                    int crabMarine = int.Parse(inputNumber);
                    crabMarines.Add(crabMarine);
                    if (maxHorizontal < crabMarine) maxHorizontal = crabMarine;
                }
            }

            //Find least amount of fuel required to move them to same position
            int minFuel = int.MaxValue;
            for (int i = 0; i < maxHorizontal; i++)
            {
                int fuel = 0;
                foreach (int crab in crabMarines)
                {
                    fuel += SumSequence(Math.Abs(crab - i));
                }
                if (fuel < minFuel) minFuel = fuel;
            }

            //Returns fuel
            Console.WriteLine(minFuel);
        }
    }
}