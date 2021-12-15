﻿namespace AdventOfCode.Day11
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public static class Challange2
    {
        private static readonly int maxSteps = 1000000;
        private static ulong flashes = 0;

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static int DoChallange(string input)
        {
            flashes = 0;

            //Read input data from text file and splits them by line
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            //Parse input into table
            int[,] table = new int[inputData[0].Length, inputData.Length];

            int tableWidth = table.GetLength(0);
            int tableHeight = table.GetLength(1);

            for (int y = 0; y < inputData.Length; y++)
            {
                for (int x = 0; x < inputData[0].Length; x++)
                {
                    table[x, y] = inputData[y][x] - '0';
                }
            }

            //Run until maximum steps exceeded
            int step;
            for (step = 0; step < maxSteps; step++)
            {
                //Increase energy and pulse if required of every octopus in table
                for (int y = 0; y < tableHeight; y++)
                {
                    for (int x = 0; x < tableWidth; x++)
                    {
                        IncreaseAndPulse(x, y, ref table);
                    }
                }
                //Reset every octopus that pulsed
                for (int y = 0; y < tableHeight; y++)
                {
                    for (int x = 0; x < tableWidth; x++)
                    {
                        if (table[x, y] > 9) table[x, y] = 0;
                    }
                }

                //If all octopi flashed during this step, break out else reset amount of flashes
                if (flashes == (ulong)(tableHeight * tableWidth))
                {
                    step++;
                    break;
                }
                flashes = 0;
            }

            //Return the result
            return step;
        }

        /// <summary>
        /// Increases every octopus energy by 1, if equal to 10 (flashed exactly once),
        /// increase all the neighbour octopi energy charges and check them.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="table"></param>
        private static void IncreaseAndPulse(int x, int y, ref int[,] table)
        {
            int tableWidth = table.GetLength(0);
            int tableHeight = table.GetLength(1);
            table[x, y]++;
            if (table[x, y] != 10) return;

            flashes++;
            for (int ny = -1; ny <= 1; ny++)
            {
                int ry = y + ny;
                if (ry < 0 || ry >= tableHeight) continue;

                for (int nx = -1; nx <= 1; nx++)
                {
                    int rx = x + nx;
                    if (rx < 0 || rx >= tableWidth || (nx == 0 && ny == 0)) continue;

                    IncreaseAndPulse(rx, ry, ref table);
                }
            }
        }
    }
}