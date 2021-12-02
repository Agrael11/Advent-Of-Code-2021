using System;
using System.IO;

namespace AdventOfCode.Day2.Puzzle1
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("inputData.txt");
            string[] inputData = sr.ReadToEnd().TrimEnd('\n').Split('\n');

            int horizontal = 0;
            int depth = 0;

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
            Console.WriteLine(horizontal*depth);
        }
    }
}