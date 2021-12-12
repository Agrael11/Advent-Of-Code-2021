namespace AdventOfCode.Day05
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
        public long DoChallange(string input)
        {
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            //Create a table and fill it with lines
            int[,] table = new int[1000, 1000];
            for (int i = 0; i < inputData.Length; i++)
            {
                DoLine(inputData[i], ref table);
            }

            //Count intersetions
            int intersections = 0;

            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (table[x, y] >= 2)
                    {
                        intersections++;
                    }
                }
            }

            //Return the result
            return intersections;
        }

        //Write Line into the table
        static void DoLine(string lineData, ref int[,] table)
        {
            //First parse the line data
            string[] sides = lineData.Split(" -> ");
            int x1 = int.Parse(sides[0].Split(',')[0]);
            int y1 = int.Parse(sides[0].Split(',')[1]);
            int x2 = int.Parse(sides[1].Split(',')[0]);
            int y2 = int.Parse(sides[1].Split(',')[1]);

            if ((x1 == x2) || (y1 == y2) || (Math.Abs(x2 - x1) - Math.Abs(y2 - y1) == 0)) //Horizontal, vertical or 45° diagonal
            {
                int orthoDist = Math.Abs(x2 - x1);
                if (orthoDist == 0) orthoDist = Math.Abs(y2 - y1);
                int horizontalOrientation = (x2 - x1) / ((x2 - x1 == 0) ? 1 : Math.Abs(x2 - x1));
                int verticalOrientation = (y2 - y1) / ((y2 - y1 == 0) ? 1 : Math.Abs(y2 - y1));

                for (int i = 0; i <= orthoDist; i++)
                {
                    int x = (x1 + horizontalOrientation * i);
                    int y = (y1 + verticalOrientation * i);
                    table[x, y]++;
                }
            }
        }
    }
}