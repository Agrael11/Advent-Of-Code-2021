namespace AdventOfCode.Day10
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public class Challange1
    {
        static readonly Dictionary<char, int> scoreBoard = new() { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public int DoChallange(string input)
        {
            //Keep score
            int score = 0;

            //Look trough all lines, and check for corrupted lines. get the first corrupted character, add it's value into score.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n'); ;
            foreach (string line in inputData)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ')' || line[i] == '>' || line[i] == '}' || line[i] == ']') continue;
                    (char c, int pos) = FindEnding(i, line);
                    if (pos == -1) continue;
                    if (isPair(line[i], c)) continue;
                    score += scoreBoard[c];
                    break;
                }
            }

            //Return the result
            return score;
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