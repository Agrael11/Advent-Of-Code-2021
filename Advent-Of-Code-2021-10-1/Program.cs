using System;
using System.IO;

namespace AdventOfCode.Day10.Puzzle1
{
    /// <summary>
    /// Main Class for Day 10 - Challange 1 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static Dictionary<char, int> scoreBoard = new() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };

        static void Main()
        {
            //Read input data from text file and splits them by line
            string[] inputData;
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n');
            }

            //keep score
            int score = 0;

            //look trough all lines, and check for corrupted lines. get the first corrupted character, add it's value into score.
            foreach (string line in inputData)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                    (char c, int pos) = FindEnding(i, line);
                    if (pos == -1) continue;
                    if (isPair(line[i], c)) continue;
                    score += scoreBoard[c];
                    Console.WriteLine($"Line: {((line.Length >= 60) ? (line.Substring(0, 60) + "..." + line[line.Length - 1]) : line)}" +
                        $", error: {line[i]}->{c}. {scoreBoard[c]} points.");
                    break;
                }
            }

            //Print result.
            Console.WriteLine($"Total : {score} points.");
        }

        /// <summary>
        /// Just checks if two characters form pair
        /// </summary>
        /// <param name="opening"></param>
        /// <param name="ending"></param>
        /// <returns></returns>
        static bool isPair(char opening, char ending)
        {
            if (opening == '(') return ending == ')';
            if (opening == '[') return ending == ']';
            if (opening == '{') return ending == '}';
            if (opening == '<') return ending == '>';
            return false;
        }

        /// <summary>
        /// Finds ending character for current position, return -1 if there isn't one.
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        static (char c, int pos) FindEnding(int pos, string line)
        {
            int open = 0;
            for (int i = pos; i < line.Length; i++)
            {
                if (line[i] == (')') || line[i] == ']' || line[i] == '>' || line[i] == '}')
                    open--;
                if (line[i] == ('(') || line[i] == '[' || line[i] == '<' || line[i] == '{')
                    open++;
                if (open == 0) return (line[i], i);
            }
            return ('\0', -1);
        }
    }
}