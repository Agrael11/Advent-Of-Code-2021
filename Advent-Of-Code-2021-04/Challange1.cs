namespace AdventOfCode.Day04
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
            //Parse boards and lottery numbers
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            SplitNumbersEx(inputData[0], out List<int> numbers);

            List<BingoBoard> boards = new();
            for (int i = 2; i < inputData.Length; i += 6)
            {
                boards.Add(new BingoBoard(inputData, i));
            }

            //Check every board for wining, find the first winning one
            (BingoBoard? board, int calledNumber) = DoBingo(ref boards, ref numbers);

            //Add up all uncalled numbers and multiply them by last called number
            if (board == null) return -1;
            
            int result = 0;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    result += board.GetNumberAtIfStatus(x, y, false);
                }
            }
            result *= calledNumber;
            
            //Return the result
            return result;
        }

        /// <summary>
        /// Splits input numbers in string
        /// </summary>
        /// <param name="inNumbers"></param>
        /// <param name="outNumbers"></param>
        static void SplitNumbersEx(string inNumbers, out List<int> outNumbers)
        {
            outNumbers = new();
            string[] splitLine = inNumbers.Split(',');
            for (int i = 0; i < splitLine.Length; i++)
            {
                outNumbers.Add(int.Parse(splitLine[i]));
            }
        }

        /// <summary>
        /// Base bingo routine:
        /// Goes trough all numbers and for each one check every board for bingo. If found returns
        /// it, along with last drawn number.
        /// </summary>
        /// <param name="boards"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static (BingoBoard? board, int calledNumber) DoBingo(ref List<BingoBoard> boards, ref List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < boards.Count; j++)
                {
                    boards[j].CheckIfNumber(numbers[i]);
                    if (boards[j].BingoCheck())
                    {
                        return (boards[j], numbers[i]);
                    }
                }
            }
            return (null, -1);
        }
    }
}