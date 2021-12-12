namespace AdventOfCode.Day02
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public class Challange1
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public int DoChallange(string input)
        {
            //Defines horizontal position and depth of submarine, both starting at 0;
            int horizontal = 0;
            int depth = 0;

            //Goes trough every line of input, increases horizontal if line contains "forward" command,
            //increases depth if line contains "down" command, decreases depth if line contains "up" command.
            //Amount of increase/decrease is give after the command, divided by space
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            for (int i = 0; i < inputData.Length; i++)
            {
                string[] currentInput = inputData[i].Split(' ');
                switch (currentInput[0])
                {
                    case "forward":
                        horizontal += int.Parse(currentInput[1]);
                        break;
                    case "down":
                        depth += int.Parse(currentInput[1]);
                        break;
                    case "up":
                        depth -= int.Parse(currentInput[1]);
                        break;
                }
            }

            //At the end return result of position * depth.
            return horizontal * depth;
        }
    }
}