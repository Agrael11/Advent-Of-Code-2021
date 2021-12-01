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
            
            int prevNumber = int.Parse(inputData[0]);
            int increaseCount = 0;

            for (int i = 1; i < inputData.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(inputData[i])) break;

                int number = int.Parse(inputData[i]);

                Console.Write($"{prevNumber}->{number}: ");

                if (number > prevNumber)
                {
                    Console.WriteLine("(Increased)");
                    increaseCount++;
                }
                else
                {
                    Console.WriteLine("(Decreased or equal)");
                }
                prevNumber = number;
            }

            Console.WriteLine(increaseCount);
        }
    }
}