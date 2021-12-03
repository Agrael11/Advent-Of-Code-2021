using System;
using System.IO;

namespace AdventOfCode.Day2.Puzzle1
{
    /// <summary>
    /// Main Class for Day 2 - Challange 1 of Advent of Code 2021
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

            //Defines horizontal position and depth of submarine, both starting at 0;
            int horizontal = 0;
            int depth = 0;

            //Goes trough every line of input, increases horizontal if line contains "forward" command,
            //increases depth if line contains "down" command, decreases depth if line contains "up" command.
            //Amount of increase/decrease is give after the command, divided by space
            for (int i = 0; i < inputData.Length; i++)
            {
                string[] input = inputData[i].Split(' ');
                switch (input[0])
                {
                    case "forward":
                        horizontal += int.Parse(input[1]);
                        break;
                    case "down":
                        depth += int.Parse(input[1]);
                        break;
                    case "up": 
                        depth -= int.Parse(input[1]);
                        break;
                }
            }

            //At the end write a number of increased inputs.
            Console.WriteLine(horizontal*depth);
        }
    }
}