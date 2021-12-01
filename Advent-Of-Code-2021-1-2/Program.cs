using System;
using System.IO;

namespace AdventOfCode.Day1.Puzzle1
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("inputData.txt");
            string[] inputData = sr.ReadToEnd().Split('\n');

            int prevSum = GetSum(0, ref inputData);
            int increaseCount = 0;

            for (int i = 1; i < inputData.Length - 3; i++)
            {
                int number = GetSum(i, ref inputData);

                Console.Write($"{prevSum}->{GetSumText(i, ref inputData)} = {number}: ");

                if (number > prevSum)
                {
                    Console.WriteLine("(Increased)");
                    increaseCount++;
                }
                else
                {
                    Console.WriteLine("(Decreased or equal)");
                }
                prevSum = number;
            }
            Console.WriteLine(increaseCount);
        }

        static int GetSum(int index, ref string[] inputData)
        {
            return int.Parse(inputData[index]) + int.Parse(inputData[index + 1]) + int.Parse(inputData[index + 2]);
        }

        static string GetSumText(int index, ref string[] inputData)
        {
            return $"{inputData[index]} + {inputData[index + 1]} + {inputData[index + 2]}";
        }
    }
}