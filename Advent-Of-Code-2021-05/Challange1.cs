namespace AdventOfCode.Day05
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
            //Create a table and fill it with lines
            int[,] table = new int[1000, 1000];
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
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

            if (x1 == x2) //if horizontal
            {
                for (int i = y1; i != y2; i += (y2 - y1) / Math.Abs(y2 - y1))
                {
                    table[x1, i]++;
                }
                table[x1, y2]++;
            }
            else if (y1 == y2) //If vertical
            {
                for (int i = x1; i != x2; i += (x2 - x1) / Math.Abs(x2 - x1))
                {
                    table[i, y1]++;
                }
                table[x2, y1]++;
            }
        }
    }
}