using System;
using System.IO;

namespace AdventOfCode.Day10.Puzzle2
{
    /// <summary>
    /// Main Class for Day 10 - Challange 2 of Advent of Code 2021
    /// </summary>
    class Program
    {
        static Dictionary<char, ulong> scoreBoard = new() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

        static void Main()
        {
            //Read input data from text file and splits them by line
            string[] inputData;
            using (StreamReader sr = new("inputData.txt"))
            {
                inputData = sr.ReadToEnd().Replace("\r", "").TrimEnd('\n').Split('\n');
            }

            //keep score
            List<ulong> scores = new List<ulong>();

            //look trough all lines.
            foreach (string line in inputData)
            {
                //If line is corrupted, ignore it
                if (CheckIfLineBroken(line)) continue;

                //Find unended characters and remember them (in reverse order), for each missing character multiply score by 5 and add its value.
                ulong score = 0;
                string fixString = "";
                for (int i = line.Length-1; i >= 0 ; i--)
                {
                    if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                    (char c, int pos) = FindEnding(i, line);
                    if (pos != -1)
                    {
                        if (isPair(line[i], c)) continue;
                        Console.WriteLine($"It should not get here");
                        break;
                    }
                    else
                    {
                        char pair = getPair(line[i]);
                        fixString += pair;
                        score *= 5;
                        score += scoreBoard[pair];
                    }
                }

                //add score into list
                scores.Add(score);
                Console.WriteLine($"Line: {((line.Length >= 40) ? (line.Substring(0, 40) + "..." + line[line.Length - 1]) : line)}" +
                    $" incomplete, fixing: {fixString}. Score: {score}");
            }

            //Sort scores and print median
            scores.Sort();

            Console.WriteLine($"Total : {scores[scores.Count/2 ]} points.");
        }

        static bool CheckIfLineBroken(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                (char c, int pos) = FindEnding(i, line);
                if (pos == -1) continue;
                if (isPair(line[i], c)) continue;
                Console.WriteLine($"Line: {((line.Length >= 40) ? (line.Substring(0, 40) + "..." + line[line.Length - 1]) : line)}" +
                    $", error: {line[i]}->{c}.");
                return true;
            }
            return false;
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

        static char getPair(char opening)
        {
            if (opening == '(') return ')';
            if (opening == '[') return ']';
            if (opening == '{') return '}';
            if (opening == '<') return '>';
            return '\0';
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