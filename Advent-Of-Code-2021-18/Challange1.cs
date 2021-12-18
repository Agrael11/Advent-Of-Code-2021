namespace AdventOfCode.Day18
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public static partial class Challange1
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

            SnailfishNumber mainPair = SnailfishNumber.MakeNumber(inputData[0]);


            //For each snailfish number in list, add it to main numbers and reduce it.
            for (int i = 1; i < inputData.Length; i++)
            {
                SnailfishNumber newPair = SnailfishNumber.MakeNumber(inputData[i]);
                mainPair = new Pair(mainPair, newPair);

                SnailfishNumber.SetMetadata(mainPair, 0);
                SnailfishNumber.Reduce((Pair)mainPair);
            }

            return mainPair.Magnitude();
        }
    }
}