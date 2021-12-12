namespace AdventOfCode.Day02
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public class Challange2
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public int DoChallange(string input)
        {
            //Defines horizontal position and depth and aim of submarine, both starting at 0;
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            //Goes trough every line of input.
            //Increases aim if line contains "down" command, decreases aim if line contains "up" command.
            //If line contains "forward", increase horizontal by amount AND depth by amount multiplied by current aim
            //Amount of increase/decrease is give after the command, divided by space
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n'); 
            for (int i = 0; i < inputData.Length; i++)
            {
                string[] currentInput = inputData[i].Split(' ');
                switch (currentInput[0])
                {
                    case "forward":
                        horizontal += int.Parse(currentInput[1]);
                        depth += aim * int.Parse(currentInput[1]);
                        break;
                    case "down":
                        aim += int.Parse(currentInput[1]);
                        break;
                    case "up":
                        aim -= int.Parse(currentInput[1]);
                        break;
                }
            }

            //At the end return result of position * depth.
            return horizontal * depth;
        }
    }
}