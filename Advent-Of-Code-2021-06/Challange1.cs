namespace AdventOfCode.Day06
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
            //Parse data into jellyfishes
            List<int> jellyfish = new();

            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            for (int i = 0; i < inputData.Length; i++)
            {
                foreach (string fish in inputData[i].Split(','))
                {
                    jellyfish.Add(int.Parse(fish));
                }
            }

            //simulate 80 days
            for (int day = 0; day < 80; day++)
            {
                //Store old jellyfish count
                int oldcount = jellyfish.Count;
                //One day
                for (int fishIndex = 0; fishIndex < oldcount; fishIndex++)
                {
                    if (jellyfish[fishIndex] == 0)
                    {
                        jellyfish[fishIndex] = 6;
                        jellyfish.Add(8);
                    }
                    else
                    {
                        jellyfish[fishIndex]--;
                    }
                }
            }

            //Return the amount of jellyfish
            return jellyfish.Count;
        }
    }
}