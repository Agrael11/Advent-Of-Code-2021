using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day9.Puzzle1
{
    /// <summary>
    /// Main Class for Day 9 - Challange 1 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static int width;
        static int height;

        static void Main()
        {
            //Read input data from text file and splits them by line
            List<string> inputData = new();
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n').ToList();
            }

            //Get Width and Height & Parse HeightMap data
            width = inputData[0].Length;
            height = inputData.Count;

            ushort[,] heightMap = new ushort[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMap[x,y] = (ushort)(inputData[y][x] - '0');
                }
            }

            //Check for lowest points in heightmap, add their value + 1 into total risk value.
            int totalRisk = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (CheckIfLowestPoint(x, y, ref heightMap))
                    {
                        totalRisk += heightMap[x, y] + 1;
                    }
                }
            }

            //Print out risk value
            Console.WriteLine(totalRisk);
        }

        /// <summary>
        /// This function checks if point in heigtmap is lowest point from its orthogonal neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        static bool CheckIfLowestPoint(int x, int y, ref ushort[,] heightMap)
        {
            ushort current = heightMap[x, y];

            if ((x != 0) && (heightMap[x - 1,y ] <= current)) return false;
            if ((x != width - 1) && (heightMap[x + 1, y] <= current)) return false;
            if ((y != 0) && (heightMap[x, y - 1] <= current)) return false;
            if ((y != height - 1) && (heightMap[x, y + 1] <= current)) return false;

            return true;
        }
    }
}