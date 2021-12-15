namespace AdventOfCode.Day10
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public static class Challange2
    {
        private static readonly Dictionary<char, ulong> scoreBoard = new() { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static ulong DoChallange(string input)
        { 
            //Keep score
            List<ulong> scores = new();

            //Look trough all lines.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            foreach (string line in inputData)
            {
                //If line is corrupted, ignore it
                if (CheckIfLineBroken(line)) continue;

                //Find unended characters and remember them (in reverse order), for each missing character multiply score by 5 and add its value.
                ulong score = 0;
                string fixString = "";
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                    (char c, int pos) = FindEnding(i, line);
                    if (pos != -1)
                    {
                        if (IsPair(line[i], c)) continue;
                        Console.WriteLine($"It should not get here");
                        break;
                    }
                    else
                    {
                        char pair = GetPair(line[i]);
                        fixString += pair;
                        score *= 5;
                        score += scoreBoard[pair];
                    }
                }

                //add score into list
                scores.Add(score);
            }

            //Sort scores and return the median
            scores.Sort();
            return scores[scores.Count / 2];
        }

        static bool CheckIfLineBroken(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                (char c, int pos) = FindEnding(i, line);
                if (pos == -1) continue;
                if (IsPair(line[i], c)) continue;
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
        static bool IsPair(char opening, char ending)
        {
            if (opening == '(') return ending == ')';
            if (opening == '[') return ending == ']';
            if (opening == '{') return ending == '}';
            if (opening == '<') return ending == '>';
            return false;
        }

        static char GetPair(char opening)
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