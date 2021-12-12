using System;
using System.Collections.Generic;

namespace AdventOfCode.Day04
{
    /// <summary>
    /// Class taking care of Bingo Board related stuff
    /// </summary>
    class BingoBoard
    {
        //Set table of numbers and their checked values
        private readonly (int number, bool status)[,] boardNumbersAndStatus;

        /// <summary>
        /// Initalizates variables and parses input at starting index
        /// </summary>
        /// <param name="data"></param>
        /// <param name="startIndex"></param>
        public BingoBoard(string[] data, int startIndex)
        {
            boardNumbersAndStatus = new (int number, bool status)[5, 5];
            for (int y = 0; y < 5; y++)
            {
                string[] numbers = data[startIndex + y].Replace("  ", " ").TrimStart(' ').Split(' ');
                for (int x = 0; x < 5; x++)
                {
                    boardNumbersAndStatus[x, y].number = int.Parse(numbers[x]);
                    boardNumbersAndStatus[x, y].status = false;
                }
            }
        }

        /// <summary>
        /// Checks if number is same and sets Status
        /// </summary>
        /// <param name="number"></param>
        public void CheckIfNumber(int number)
        {
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    if (boardNumbersAndStatus[x, y].number == number) boardNumbersAndStatus[x, y].status = true;
                }
            }
        }

        /// <summary>
        /// Checks rows and columns for bingo
        /// </summary>
        /// <returns></returns>
        public bool BingoCheck()
        {
            for (int x = 0; x < 5; x++)
            {
                int numbers = 0;
                for (int y = 0; y < 5; y++)
                {
                    if (boardNumbersAndStatus[x, y].status) numbers++;
                }
                if (numbers == 5) return true;
            }
            for (int y = 0; y < 5; y++)
            {
                int numbers = 0;
                for (int x = 0; x < 5; x++)
                {
                    if (boardNumbersAndStatus[x, y].status) numbers++;
                }
                if (numbers == 5) return true;
            }
            return false;
        }

        /// <summary>
        /// Gets numbers at position if status is equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int GetNumberAtIfStatus(int x, int y, bool status)
        {
            if (boardNumbersAndStatus[x, y].status == status)
                return boardNumbersAndStatus[x, y].number;
            return 0;
        }
    }
}