namespace AdventOfCode.Day01
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
            //Defines Previous Number as first number in the list, and counter of increased items.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            
            int prevNumber = int.Parse(inputData[0]);
            int increaseCount = 0;

            //Goes trough every line of input, starting at second element (since first one is already parsed as prevNumber)
            //If current line is larger than previous line, increment the counter.
            for (int i = 1; i < inputData.Length; i++)
            {
                int number = int.Parse(inputData[i]);

                if (number > prevNumber)
                {
                    increaseCount++;
                }

                prevNumber = number;
            }

            //At the end return a number of increased inputs.
            return increaseCount;
        }
    }
}