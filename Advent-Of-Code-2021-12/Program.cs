namespace AdventOfCode.Day12
{
    /// <summary>
    /// Main Class for Day 12 of Advent of Code 2021
    /// </summary>
    public class Program
    {
        static void Main()
        {
            //Read input data from text file and call Part 1
            StreamReader sr = new("inputData.txt");
            string input = sr.ReadToEnd();
            sr.Close();

            //Call Challange 1
             new Challange1().DoChallange(input);

            //Call Challange 2
            new Challange2().DoChallange(input);
        }
    }
}