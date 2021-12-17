namespace AdventOfCode.Day17
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
            string[] inputData = input[(input.IndexOf(':') + 2)..].Split(", ");
            string[] xInfo = inputData[0][(inputData[0].IndexOf('=') + 1)..].Split("..");
            string[] yInfo = inputData[1][(inputData[1].IndexOf('=') + 1)..].Split("..");
            int x1 = int.Parse(xInfo[0]);
            int x2 = int.Parse(xInfo[1]);
            int y1 = int.Parse(yInfo[0]);
            int y2 = int.Parse(yInfo[1]);

            int hits = 0;

            //Run trough all verticals and horizontal velocities that have chance to succeed
            for (int yStartVelocity = Math.Abs(y1); yStartVelocity >= -Math.Abs(y1); yStartVelocity--)
            {
                for (int xStartVelocity = TriangularRoot(x1); xStartVelocity <= x2; xStartVelocity++)
                {
                    //Set starting location (0,0) and copy starting velocity to current velocity
                    int yLocation = 0;
                    int xLocation = 0;
                    int xCurrentVelocity = xStartVelocity;
                    int yCurrentVelocity = yStartVelocity;

                    //Repeat until we haven't left target completely
                    while (xLocation < x2 && yLocation > y1)
                    {
                        //Apply current velocity to position
                        xLocation += xCurrentVelocity;
                        yLocation += yCurrentVelocity;

                        //Apply drag to horizontal velocity (i know I should be checking for < 0 too, but it never happens
                        if (xCurrentVelocity > 0) xCurrentVelocity--;
                        //Apply gravity to vertical velocity
                        yCurrentVelocity--;

                        //Check if hit happened, if yes - count and end this loop
                        if (xLocation >= x1 &&  xLocation <= x2 && yLocation >= y1 && yLocation <= y2)
                        {
                            hits++;
                            break;
                        }
                    }
                }
            }

            return hits;
        }

        /// <summary>
        /// Calculates root of triangular number
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int TriangularRoot(int source)
        {
            return (int)((Math.Sqrt(8 * source + 1) - 1) / 2);
        }
    }
}