namespace AdventOfCode.Day04
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
            //Parse the bingo boards and numbers
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            SplitNumbersEx(inputData[0], out List<int> numbers);

            List<BingoBoard> boards = new();
            for (int i = 2; i < inputData.Length; i += 6)
            {
                boards.Add(new BingoBoard(inputData, i));
            }

            //Find the LAST winning board
            (BingoBoard? board, int calledNumber) = DoBingo(ref boards, ref numbers);
            if (board == null) return -1;

            //Add the uncalled numbers and multiply them by last called number
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
        /// Base bingo routine:
        /// Goes trough all numbers and for each one check every board for bingo.
        /// Checks for last board that wins.
        /// </summary>
        /// <param name="boards"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static (BingoBoard? board, int calledNumber) DoBingo(ref List<BingoBoard> boards, ref List<int> numbers)
        {
            BingoBoard? bingoWinnerLast = null;
            int numberLast = -1;
            int winningBoards = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = 0; j < boards.Count; j++)
                {
                    if (!boards[j].BingoCheck())
                    {
                        boards[j].CheckIfNumber(numbers[i]);
                        if (boards[j].BingoCheck())
                        {
                            winningBoards++;
                            bingoWinnerLast = boards[j];
                            numberLast = numbers[i];
                            if (boards.Count - winningBoards == 0)
                                return (bingoWinnerLast, numberLast);
                        }
                    }
                }
            };
            return (bingoWinnerLast, numberLast);
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
    }
}