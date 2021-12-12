namespace AdventOfCode.Day04
{
    /// <summary>
    /// Main Class for Day 4 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file
            string inputData = File.ReadAllText("inputData.txt");

            //Do challange 1
            Console.WriteLine($"Result of Day 4, Challange 1 is:{new Challange1().DoChallange(inputData)}.");

            //Do challange 2
            Console.WriteLine($"Result of Day 4, Challange 2 is:{new Challange2().DoChallange(inputData)}.");
        }
    }
}