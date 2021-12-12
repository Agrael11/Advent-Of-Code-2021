namespace AdventOfCode.Day01
{
    /// <summary>
    /// Main Class for Day 1 of Advent of Code 2021
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            //Read input data from text file
            string inputData = File.ReadAllText("inputData.txt");

            //Do challange 1
            Console.WriteLine($"Result of Day 1, Challange 1 is:{new Challange1().DoChallange(inputData)}.");

            //Do challange 2
            Console.WriteLine($"Result of Day 1, Challange 2 is:{new Challange2().DoChallange(inputData)}.");
        }
    }
}