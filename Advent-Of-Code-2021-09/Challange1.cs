namespace AdventOfCode.Day09
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
            //Get Width and Height & Parse HeightMap data
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            int width = inputData[0].Length;
            int height = inputData.Length;

            ushort[,] heightMap = new ushort[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    heightMap[x, y] = (ushort)(inputData[y][x] - '0');
                }
            }

            //Check for lowest points in heightmap, add their value + 1 into total risk value.
            int totalRisk = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (CheckIfLowestPoint(x, y, ref heightMap))
                    {
                        totalRisk += heightMap[x, y] + 1;
                    }
                }
            }

            //Return the result
            return totalRisk;
        }

        /// <summary>
        /// This function checks if point in heigtmap is lowest point from its orthogonal neighbours
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        static bool CheckIfLowestPoint(int x, int y, ref ushort[,] heightMap)
        {
            int width = heightMap.GetLength(0);
            int height = heightMap.GetLength(1);
            ushort current = heightMap[x, y];

            if ((x != 0) && (heightMap[x - 1, y] <= current)) return false;
            if ((x != width - 1) && (heightMap[x + 1, y] <= current)) return false;
            if ((y != 0) && (heightMap[x, y - 1] <= current)) return false;
            if ((y != height - 1) && (heightMap[x, y + 1] <= current)) return false;

            return true;
        }
    }
}