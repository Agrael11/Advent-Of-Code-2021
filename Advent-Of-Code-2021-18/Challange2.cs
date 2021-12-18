namespace AdventOfCode.Day18
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public static class Challange2
    {

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static int DoChallange(string input)
        {
            //Parse Input Data
            input = input.Replace("\r", "").TrimEnd('\n');

            string[] inputData = input.Split('\n');

            int maxMagnitude = int.MinValue;

            //for each pair of numbers in list, try to add them and reduce them
            //if their magnituted is highest, rememer it
            for (int firstOne = 0; firstOne < inputData.Length; firstOne++)
            {
                for (int secondOne = 0; secondOne < inputData.Length; secondOne++)
                {
                    if (firstOne == secondOne)
                        continue;

                    SnailfishNumber firstNum = SnailfishNumber.MakeNumber(inputData[firstOne]);
                    SnailfishNumber secondNum = SnailfishNumber.MakeNumber(inputData[secondOne]);
                    SnailfishNumber realNum = new Pair(firstNum, secondNum);
                    SnailfishNumber.SetMetadata(realNum, 0);
                    SnailfishNumber.Reduce((Pair)realNum);
                    if (realNum.Magnitude() > maxMagnitude)
                    {
                        maxMagnitude = realNum.Magnitude();
                    }
                }
            }

            return maxMagnitude;
        }
    }
}