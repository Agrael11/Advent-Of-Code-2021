namespace AdventOfCode.Day03
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
            //Initial definition of gammaRate (starting at 0)
            int gammaRate = 0;

            //Looking trough every position of every number in the list - most common number in bit position will get
            //that position in gammaRate - so if most common bit on first position is 0, the gammaRate will have 0 on
            //first position.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            for (int i = 0; i < inputData[0].Length; i++)
            {
                int mostCommon = GetMostCommonBit(i, ref inputData);
                gammaRate += mostCommon * (int)Math.Pow(2, inputData[0].Length - 1 - i);
            }

            //Epsilon Rate is essentailly reversed gamma rate, so I just reverse all bits in it.
            int epsilonRate = (int)Math.Pow(2, inputData[0].Length) - 1 - gammaRate;
            
            //Return power consumption
            return epsilonRate * gammaRate;
        }

        /// <summary>
        /// Gets the most common bit on the position in the list
        /// To do that it searches all numbers in the list, and increments the counter every time it founds 1,
        /// If there is more 0 than is 1s, return 1, otherwise it will return 1.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        static int GetMostCommonBit(int index, ref string[] inputData)
        {
            int ones = 0;
            for (int i = 0; i < inputData.Length; i++)
            {
                if (inputData[i][index] == '1') ones++;
            }
            if (inputData.Length - ones > ones) return 0;
            return 1;
        }
    }
}