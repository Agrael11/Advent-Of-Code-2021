namespace AdventOfCode.Day21
{
    /// <summary>
    /// Main Class for Challange 2 -- Thanks u/ArrekinPL for help!!
    /// </summary>
    public static class Challange2
    {
        static readonly List<int> rollList = new ();
        static readonly Dictionary<int, ulong> rollMap = new ();

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static ulong DoChallange(string input)
        {
            //Parse input
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            int start1 = int.Parse(inputData[0][inputData[0].LastIndexOf(' ')..]);
            int start2 = int.Parse(inputData[1][inputData[1].LastIndexOf(' ')..]);

            //Generate all possible rolls, and how many times that roll can happen
            for (int roll1 = 1; roll1 <= 3; roll1++)
            {
                for (int roll2 = 1; roll2 <= 3; roll2++)
                {
                    for (int roll3 = 1; roll3 <= 3; roll3++)
                    {
                        int roll = roll1 + roll2 + roll3;
                        if (rollList.Contains(roll))
                        {
                            rollMap[roll]++;
                        }
                        else
                        {
                            rollList.Add(roll);
                            rollMap.Add(roll, 1);
                        }
                    }
                }
            }
            rollList.Sort();

            //Run, and print the player that wins more times
            ulong wins1 = 0;
            ulong wins2 = 0;

            DoTheRun(0, 0, start1, start2, ref wins1, ref wins2, 1);

            if (wins1 > wins2) return wins1;

            return wins2;
        }


        static void DoTheRun(int score1, int score2, int position1, int position2, ref ulong wins1, ref ulong wins2, ulong rollCount)
        {
            //Remember player1 score at start of this universe split
            int old1Score = score1;
            int old1Position = position1;
            foreach (int rolled1 in rollList)
            {
                //Play using rolled value, if won, increase win number for player 1 by amount of times that roll can happen * how many times
                //can this universe happen and continue to next possibility
                if (PlayPlayer(ref position1, ref score1, rolled1))
                {
                    ulong oldWin = wins1;
                    wins1 += rollMap[rolled1] * rollCount;
                    if (wins1 < oldWin) throw new Exception();
                    score1 = old1Score;
                    position1 = old1Position;
                    continue;
                }

                //Remember player12 score at start of this split
                int old2Score = score2;
                int old2Position = position2;
                foreach (int rolled2 in rollList)
                {
                    //Same same
                    if (PlayPlayer(ref position2, ref score2, rolled2))
                    {
                        ulong oldWin = wins2;
                        wins2 += rollMap[rolled2] * rollMap[rolled1] * rollCount;
                        if (wins2 < oldWin) throw new Exception();
                        score2 = old2Score;
                        position2 = old2Position;
                        continue;
                    }

                    DoTheRun(score1, score2, position1, position2, ref wins1, ref wins2, rollMap[rolled2] * rollMap[rolled1] * rollCount);

                    //Restore original score from split before the next possiblity
                    score2 = old2Score;
                    position2 = old2Position;
                }


                //Restore original score from split before the next possiblity
                score1 = old1Score;
                position1 = old1Position;
            }
        }

        ///Add roll to player position, resseting to 1 if it's more then 10, add players position to players score,
        ///return true if more or equal to 21
        static bool PlayPlayer(ref int playerPos, ref int playerScore, int roll)
        {
            playerPos += roll;
            if (playerPos > 10) playerPos -= 10;
            playerScore += playerPos;
            return playerScore >= 21;
        }
    }
}