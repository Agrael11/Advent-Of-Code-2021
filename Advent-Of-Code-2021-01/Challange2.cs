namespace AdventOfCode.Day01
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
            //Defines Previous Sum as Sum of first three element on the list, and counter of increased sums.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            int prevSum = GetSum(0, ref inputData);
            int increaseCount = 0;

            //Goes trough every line of input, starting at second element (since first one is already parsed as prevNumber), excluding last 2 elements
            //If sum at the current index is larger than sum at last one, increment the counter.
            for (int i = 1; i < inputData.Length - 2; i++)
            {
                int number = GetSum(i, ref inputData);

                if (number > prevSum)
                {
                    increaseCount++;
                }
                prevSum = number;
            }

            //At the end return a number of increased input sums.
            return increaseCount;
        }

        /// <summary>
        /// Gets sum of three elements in list, starting at index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static int GetSum(int index, ref string[] inputData)
        {
            return int.Parse(inputData[index]) + int.Parse(inputData[index + 1]) + int.Parse(inputData[index + 2]);
        }

        /// <summary>
        /// Makes string representing addition of three elements in list, starting at index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static string GetSumText(int index, ref string[] inputData)
        {
            return $"{inputData[index]} + {inputData[index + 1]} + {inputData[index + 2]}";
        }
    }
}