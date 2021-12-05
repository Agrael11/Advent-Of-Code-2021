using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day4.Puzzle2
{
    /// <summary>
    /// Main Class for Day 4 - Challange 2 of Advent of Code 2021
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

            //Create a table and fill it with lines
            int[,] table = new int[1000, 1000];
            for (int i = 0; i < inputData.Count; i++)
            {
                DoLine(inputData[i], ref table);
            }

            //Count intersetions
            int intersections = 0;

            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (table[x, y] >=2)
                    {
                        intersections++;
                    }
                }
            }

            Console.WriteLine($"Number of Intersections: {intersections}");
        }

        //Write Line into the table
        static void DoLine(string lineData, ref int[,] table)
        {
            //First parse the line data
            string[] sides = lineData.Split(" -> ");
            int x1 = int.Parse(sides[0].Split(',')[0]);
            int y1 = int.Parse(sides[0].Split(',')[1]);
            int x2 = int.Parse(sides[1].Split(',')[0]);
            int y2 = int.Parse(sides[1].Split(',')[1]);

            if (x1 == x2) //if horizontal
            {
                for (int i = y1; i != y2; i += (y2 - y1) / Math.Abs(y2 - y1))
                {
                    table[x1, i]++;
                }
                table[x1, y2]++;
            }
            else if (y1 == y2) //If vertical
            {
                for (int i = x1; i != x2; i += (x2 - x1) / Math.Abs(x2 - x1))
                {
                    table[i, y1]++;
                }
                table[x2, y1]++;
            }
        }
    }
}