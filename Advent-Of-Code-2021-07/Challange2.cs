namespace AdventOfCode.Day07
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
            //Parse data into crabmarines and get their biggest position
            List<int> crabMarines = new();
            int maxHorizontal = 0;
         
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            foreach (string inputLine in inputData)
            {
                foreach (string inputNumber in inputLine.Split(','))
                {
                    int crabMarine = int.Parse(inputNumber);
                    crabMarines.Add(crabMarine);
                    if (maxHorizontal < crabMarine) maxHorizontal = crabMarine;
                }
            }

            //Find least amount of fuel required to move them to same position
            int minFuel = int.MaxValue;
            for (int i = 0; i < maxHorizontal; i++)
            {
                int fuel = 0;
                foreach (int crab in crabMarines)
                {
                    fuel += SumSequence(Math.Abs(crab - i));
                }
                if (fuel < minFuel) minFuel = fuel;
            }

            //Return minimum required fuel
            return minFuel;
        }

        //Gets sum of sequence of numbers
        static int SumSequence(int input)
        {
            return (int)(input * ((input + 1) / 2.0f));
        }
    }
}