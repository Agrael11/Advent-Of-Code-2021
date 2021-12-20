namespace AdventOfCode.Day20
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
        public static ulong DoChallange(string input)
        {
            //Parse Input Data
            input = input.Replace("\r", "").TrimEnd('\n');
            string[] inputData = input.Split('\n');

            //First line is algorythm - always should be 512 characters long
            bool[] algorythm = new bool[inputData[0].Length];
            for (int index = 0; index < algorythm.Length; index++)
            {
                algorythm[index] = inputData[0][index] == '#';
            }

            //At third line image starts.
            bool[,] data = new bool[inputData[2].Length,inputData.Length - 2];
            for (int y = 2; y < inputData.Length; y++)
            {
                for (int x = 0; x < inputData[y].Length; x++)
                {
                    data[x, y-2] = inputData[y][x] == '#';
                }
            }
            Picture picture = new(data);

            //Enhance the image twice
            picture = Picture.Enhance(picture, algorythm, 2);

            //And count the amount of lit pixels.
            ulong lit = 0;
            for (int y = 0; y < picture.Height; y++)
            {
                for (int x = 0; x < picture.Width; x++)
                {
                    lit += (ulong)(picture.GetPixelAt(x, y) ? 1 : 0);
                }
            }

            return lit;
        }
    }
}