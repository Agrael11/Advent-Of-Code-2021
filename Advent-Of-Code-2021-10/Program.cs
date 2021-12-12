namespace AdventOfCode.Day10
{
    /// <summary>
    /// Main Class for Day 10 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file
            string inputData = File.ReadAllText("inputData.txt");

            //Do challange 1
            Console.WriteLine($"Result of Day 10, Challange 1 is:{new Challange1().DoChallange(inputData)}.");

            //Do challange 2
            Console.WriteLine($"Result of Day 10, Challange 2 is:{new Challange2().DoChallange(inputData)}.");
        }
    }
}