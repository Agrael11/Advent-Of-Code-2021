namespace AdventOfCode.Day17
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
            //Parse Input Data, little unnecessary
            input = input.Replace("\r", "").TrimEnd('\n');
            string[] inputData = input[(input.IndexOf(':') + 2)..].Split(", ");
            string[] xInfo = inputData[0][(inputData[0].IndexOf('=') + 1)..].Split("..");
            string[] yInfo = inputData[1][(inputData[1].IndexOf('=') + 1)..].Split("..");
            int x1 = int.Parse(xInfo[0]);
            int x2 = int.Parse(xInfo[1]);
            int y1 = int.Parse(yInfo[0]);
            int y2 = int.Parse(yInfo[1]);

            //Maximum height is triangular number of speed. If our starting speed will be higher then target area
            //maximum depth, we will jump over target area
            return TriangularNumber(Math.Abs(y1) - 1);
        }

        /// <summary>
        /// Just get the triangular number result. Simple calculation
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int TriangularNumber(int input)
        {
            return (int)(input * ((input + 1) / 2.0f));
        }
    }
}