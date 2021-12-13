namespace AdventOfCode.Day13
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
        public string DoChallange(string input)
        {
            //First find max width and height
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            int width = -1;
            int height = -1;
            int endDotInsturction = -1;

            for (int line = 0; line < inputData.Length; line++)
            {
                endDotInsturction = line;
                if (inputData[line] == "")
                    break;

                int x = int.Parse(inputData[line].Split(',')[0]);
                int y = int.Parse(inputData[line].Split(',')[1]);
                if (x + 1 > width) width = x + 1;
                if (y + 1 > height) height = y + 1;
            }

            //Fill the table with dots
            bool[,] table = new bool[width, height];

            for (int line = 0; line < endDotInsturction; line++)
            {
                int x = int.Parse(inputData[line].Split(',')[0]);
                int y = int.Parse(inputData[line].Split(',')[1]);

                table[x, y] = true;
            }

            //Do the folding (every line)
            for (int line = endDotInsturction + 1; line < inputData.Length; line++)
            {
                string instruction = inputData[line].Split('=')[0];
                int location = int.Parse(inputData[line].Split('=')[1]);
                if (instruction[instruction.Length - 1] == 'x')
                {
                    FoldTable(ref table, location, 0);
                }
                else if (instruction[instruction.Length - 1] == 'y')
                {
                    FoldTable(ref table, 0, location);
                }
            }

            //Get new length and count the dots
            width = table.GetLength(0);
            height = table.GetLength(1);

            //Put dots into string and return it
            string result = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (table[x, y])
                    {
                        result += "#";
                    }
                    else
                    {
                        result += ".";
                    }
                }
                if (y != height - 1) result += "\n";
            }

            return result;
        }

        /// <summary>
        /// Folds the table horizontally or vertically along the line. The folded line disappears
        /// </summary>
        /// <param name="table"></param>
        /// <param name="splitX"></param>
        /// <param name="splitY"></param>
        public void FoldTable(ref bool[,] table, int splitX, int splitY)
        {
            int oWidth = table.GetLength(0);
            int oHeight = table.GetLength(1);
            if (splitX == 0) //Vertical
            {
                int width = oWidth;
                int height = oHeight;

                //Figure new height
                if (splitY > (height + 1) / 2.0)
                    height = splitY - 1;
                else if ((splitY + 1) == (height + 1) / 2.0)
                {
                    height /= 2;
                }
                else
                    height -= splitY;

                //Define new table & copy unfolded content, move it down if needed
                bool[,] newTable = new bool[width, height];

                for (int y = 0; y < splitY; y++)
                {
                    int movePoint = oHeight - 1 - splitY * 2;
                    if (movePoint < 0) movePoint = 0;
                    movePoint += y;

                    for (int x = 0; x < width; x++)
                    {
                        newTable[x, movePoint] = table[x, y];
                    }
                }

                //Flip the remaining content and copy to new table
                for (int y = splitY + 1; y < oHeight; y++)
                {
                    int movePoint = height - (y - splitY);

                    for (int x = 0; x < width; x++)
                    {
                        newTable[x, movePoint] |= table[x, y];
                    }
                }

                table = newTable;
            }
            else //Horizontal
            {
                int width = oWidth;
                int height = oHeight;

                //Figure new width
                if (splitX > (width + 1) / 2.0)
                    width = splitX - 1;
                else if ((splitX + 1) == (width + 1) / 2.0)
                {
                    width /= 2;
                }
                else
                    width -= splitX;

                //Define new table and copy unfolded content, move right if needed
                bool[,] newTable = new bool[width, height];

                for (int x = 0; x < splitX; x++)
                {
                    int movePoint = oWidth - 1 - splitX * 2;
                    if (movePoint < 0) movePoint = 0;
                    movePoint += x;

                    for (int y = 0; y < height; y++)
                    {
                        newTable[movePoint, y] = table[x, y];
                    }
                }

                //Copy folded content
                for (int x = splitX + 1; x < oWidth; x++)
                {
                    int movePoint = width - (x - splitX);

                    for (int y = 0; y < height; y++)
                    {
                        newTable[movePoint, y] |= table[x, y];
                    }
                }

                table = newTable;
            }
        }
    }
}