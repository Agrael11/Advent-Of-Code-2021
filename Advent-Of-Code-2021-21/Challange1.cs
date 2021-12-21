namespace AdventOfCode.Day21
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
            //Parse input
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            int player1pos = int.Parse(inputData[0][inputData[0].LastIndexOf(' ')..]);
            int player2pos = int.Parse(inputData[1][inputData[1].LastIndexOf(' ')..]);

            //Rememeber score of each player, last roll and number of rolls
            int player1score = 0;
            int player2score = 0;

            int dice = 1;
            int rolls = 0;

            //Until either player wins (score 1000+) repeat
            while (player1score < 1000 && player2score < 1000)
            {
                //Increase player 1's position by triple dice roll
                player1pos += RollTheDiceTrice(ref dice, ref rolls);
                while (player1pos > 10) player1pos -= 10;

                //Increase player 1 score by player position
                player1score += player1pos;

                //If more than 1000 player 1 won.
                if (player1score >= 1000)
                {
                    return player2score * rolls;
                }

                player2pos += RollTheDiceTrice(ref dice, ref rolls);
                while (player2pos > 10) player2pos -= 10;

                //Increase player 2 score by player position
                player2score += player2pos;
            }

            //Player 2 won
            return player1score * rolls;
        }

        /// <summary>
        /// Rolls the dice three times and returns rolled number
        /// </summary>
        /// <param name="dice"></param>
        /// <param name="rolls"></param>
        /// <returns></returns>
        public static int RollTheDiceTrice(ref int dice, ref int rolls)
        {
            int rolled = 0;
            for (int roll = 0; roll < 3; roll++)
            {
                rolled += dice;
                dice++;
                if (dice > 100) dice = 1; //Just resets dice if over 100
                rolls++;
            }
            return rolled;
        }
    }
}