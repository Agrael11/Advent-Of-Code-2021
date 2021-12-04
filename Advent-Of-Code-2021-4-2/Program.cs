using System;
using System.IO;

namespace AdventOfCode.Day4.Puzzle2
{
    /// <summary>
    /// Main Class for Day 4 - Challange 2 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static void Main()
        {
            //Read input data from text file and splits them by line
            List<string> inputData = new();
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n').ToList();
            }

            List<int> numbers;
            SplitNumbersEx(inputData[0], out numbers);

            List<BingoBoard> boards = new List<BingoBoard>();
            for (int i = 2; i < inputData.Count(); i += 6)
            {
                boards.Add(new BingoBoard(inputData, i));
            }

            (BingoBoard? board, int calledNumber) = DoBingo(ref boards, ref numbers);
            if (board == null) Console.WriteLine("There was a problem?");
            else
            {
                int result = 0;
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        result += board.GetNumberAtIfStatus(x, y, false);
                    }
                }
                board.DrawBingo();
                result *= calledNumber;
                Console.WriteLine();
                Console.WriteLine($"Result is: {result}");
            }
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