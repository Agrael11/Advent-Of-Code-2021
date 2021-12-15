namespace AdventOfCode.Day06
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
        public static long DoChallange(string input)
        {
            //Parse data into jellyfishes
            List<long> jellyfish = new();

            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            for (int i = 0; i <= 9; i++)
            {
                jellyfish.Add(0);
            }
            for (int i = 0; i < inputData.Length; i++)
            {
                foreach (string fish in inputData[i].Split(','))
                {
                    jellyfish[int.Parse(fish)]++;
                }
            }

            //simulate 80 days
            for (int day = 0; day < 256; day++)
            {
                //store jellyfish waiting to reset
                jellyfish[9] = jellyfish[0];
                //move jellyfish one day closer
                for (int dayBorn = 1; dayBorn < 9; dayBorn++)
                {
                    jellyfish[dayBorn - 1] = jellyfish[dayBorn];
                }
                //reset the jellyfish waiting
                jellyfish[6] += jellyfish[9];
                //add new jellyfish
                jellyfish[8] = jellyfish[9];
            }

            long realCount = 0;
            for (int i = 0; i < jellyfish.Count - 1; i++)
            {
                realCount += jellyfish[i];
            }
            
            //return the amount of jellyfish
            return realCount;
        }
    }
}