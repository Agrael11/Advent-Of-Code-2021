using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Day9.Puzzle2
{
    /// <summary>
    /// Main Class for Day 9 - Challange 2 of Advent of Code 2021
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
                    heightMap[x, y] = (ushort)(inputData[y][x] - '0');
                }
            }

            //Goes trough all place is in heightmap, if it's lowest places, finds it's basin value and pushes it into list of largest three
            int[] largest = { 0, 0, 0 };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (CheckLowestPoint(x, y, ref heightMap))
                    {
                        int size = FindBasinSize(x, y, ref heightMap);
                        if (size > largest[0])
                        {
                            largest[2] = largest[1];
                            largest[1] = largest[0];
                            largest[0] = size;
                        }
                        else if (size > largest[1])
                        {
                            largest[2] = largest[1];
                            largest[1] = size;
                        }
                        else if (size > largest[2])
                        {
                            largest[2] = size;
                        }
                    }
                }
            }

            //Write result
            Console.WriteLine(largest[0] * largest[1] * largest[2]);
        }

        /// <summary>
        /// Find basin size. Replaces currently checked point with 9, if orthogonal point is lower than original value, recursively check it.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        static int FindBasinSize(int x, int y, ref ushort[,] heightMap)
        {
            int size = 1;
            int current = heightMap[x, y];
            heightMap[x, y] = 9;
            if ((x != 0) && (heightMap[x - 1, y] != 9) && (heightMap[x - 1, y] > current)) size += FindBasinSize(x - 1, y, ref heightMap);
            if ((x != width - 1) && (heightMap[x + 1, y] != 9) && (heightMap[x + 1, y] > current)) size += FindBasinSize(x + 1, y, ref heightMap);
            if ((y != 0) && (heightMap[x, y - 1] != 9) && (heightMap[x, y - 1] > current)) size += FindBasinSize(x, y - 1, ref heightMap);
            if ((y != height - 1) && (heightMap[x, y + 1] != 9) && (heightMap[x, y + 1] > current)) size += FindBasinSize(x, y + 1, ref heightMap);
            return size;
        }

        /// <summary>
        /// This function checks if point in heigtmap is lowest point from its orthogonal neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        static bool CheckLowestPoint(int x, int y, ref ushort[,] heightMap)
        {
            ushort current = heightMap[x, y];

            if ((x != 0) && (heightMap[x - 1, y] <= current)) return false;
            if ((x != width - 1) && (heightMap[x + 1, y] <= current)) return false;
            if ((y != 0) && (heightMap[x, y - 1] <= current)) return false;
            if ((y != height - 1) && (heightMap[x, y + 1] <= current)) return false;

            return true;
        }
    }
}