using System;
using System.IO;

namespace AdventOfCode.Day2.Puzzle2
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("inputData.txt");
            string[] inputData = sr.ReadToEnd().TrimEnd('\n').Split('\n');

            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            for (int i = 0; i < inputData.Length; i++)
            {
                string[] input = inputData[i].Split(' ');
                switch (input[0])
                {
                    case "forward": 
                        horizontal += int.Parse(input[1]);
                        depth += aim * int.Parse(input[1]);
                        break;
                    case "down":
                        aim += int.Parse(input[1]);
                        break;
                    case "up":
                        aim -= int.Parse(input[1]);
                        break;
                }
            }
            Console.WriteLine(horizontal * depth);
        }
    }
}