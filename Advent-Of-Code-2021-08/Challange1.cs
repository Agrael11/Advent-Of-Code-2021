namespace AdventOfCode.Day08
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public static class Challange1
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static int DoChallange(string input)
        {
            //Check numbers in output part (after " | ") of every input line. If number is 2 (2 long), 4 (4 long), 7 (3 long), or 8 (7 long) increment total counter
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            int total = 0;
            foreach (string currentInput in inputData)
            {
                string outputInfo = currentInput.Split(" | ")[1];
                foreach (string outputNumeral in outputInfo.Split(' '))
                {
                    if (outputNumeral.Length == 2 || outputNumeral.Length == 3 || outputNumeral.Length == 4 || outputNumeral.Length == 7)
                        total++;
                }
            }

            //Return the result
            return total;
        }
    }
}