namespace AdventOfCode.Day18
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public static class Challange2
    {

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static int DoChallange(string input)
        {
            //Parse Input Data
            input = input.Replace("\r", "").TrimEnd('\n');

            string[] inputData = input.Split('\n');

            int maxMagnitude = int.MinValue;

            //for each pair of numbers in list, try to add them and reduce them
            //if their magnituted is highest, rememer it
            for (int firstOne = 0; firstOne < inputData.Length; firstOne++)
            {
                for (int secondOne = 0; secondOne < inputData.Length; secondOne++)
                {
                    if (firstOne == secondOne)
                        continue;

                    SnailfishNumber firstNum = MakeNumber(inputData[firstOne]);
                    SnailfishNumber secondNum = MakeNumber(inputData[secondOne]);
                    SnailfishNumber realNum = new Pair(firstNum, secondNum);
                    SetMetadata(realNum, 0);
                    Reduce((Pair)realNum);
                    if (realNum.Magnitude() > maxMagnitude)
                    {
                        maxMagnitude = realNum.Magnitude();
                    }
                }
            }

            return maxMagnitude;
        }

        /// <summary>
        /// Reduce pair
        /// Try to explode pair of first subpair on left if possible
        /// If not, try to split pair or first subpair on left if possible
        /// If not - finished
        /// </summary>
        /// <param name="pair"></param>
        public static void Reduce(Pair pair)
        {
            pair.parent = null;
            pair.level = 0;
            while (true)
            {
                if (TryExplodePair(pair))
                {
                    continue;
                }
                if (TrySplitRegularNumber(pair))
                {
                    continue;
                }
                break;
            }
        }

        /// <summary>
        /// Helper function - rounds number up
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int Roof(double number)
        {
            if (number - Math.Floor(number) != 0)
            {
                return (int)(Math.Floor(number) + 1);
            }
            return (int)Math.Floor(number);
        }

        /// <summary>
        /// Tries to split a number. If it's pair, try to split numbers in pair.
        /// If it's a regular number and higher than 10, split it.
        /// Only split one number... Yay recursion
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool TrySplitRegularNumber(SnailfishNumber number)
        {
            if (number.GetType() == typeof(RegularNumber))
            {
                if (((RegularNumber)number).Number < 10) return false;

                RegularNumber newLeft = new RegularNumber((int)(Math.Floor(((RegularNumber)number).Number / 2.0)));
                newLeft.level = number.level + 1;
                newLeft.side = 1;
                RegularNumber newRight = new RegularNumber((int)(Roof(((RegularNumber)number).Number / 2.0)));
                newRight.level = number.level + 1;
                newRight.side = 2;
                Pair newPair = new Pair(newLeft, newRight);
                newPair.level = number.level;
                newPair.Left.parent = newPair;
                newPair.Right.parent = newPair;
                newPair.side = number.side;
                newPair.parent = number.parent;
                if (number.side == 1)
                {
                    ((Pair)number.parent).Left = newPair;
                }
                else if (number.side == 2)
                {
                    ((Pair)number.parent).Right = newPair;
                }
                return true;
            }
            else
            {
                if (TrySplitRegularNumber(((Pair)number).Left)) return true;
                if (TrySplitRegularNumber(((Pair)number).Right)) return true;
            }
            return false;
        }

        /// <summary>
        /// Find first regular number on the left side of the tree (going forward) and increase it by value.
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="value"></param>
        public static void ExplodeWithFirstLeft(Pair pair, RegularNumber value)
        {
            if (pair.Left.GetType() == typeof(RegularNumber))
            {
                RegularNumber rightPair = (RegularNumber)pair.Left;
                rightPair.Number += value.Number;
                return;
            }
            ExplodeWithFirstLeft((Pair)pair.Left, value);
        }

        /// <summary>
        /// Find first regular number on the right side of the tree (going forward) and increase it by value.
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="value"></param>
        public static void ExplodeWithFirstRight(Pair pair, RegularNumber value)
        {
            if (pair.Right.GetType() == typeof(RegularNumber))
            {
                RegularNumber rightPair = (RegularNumber)pair.Right;
                rightPair.Number += value.Number;
                return;
            }
            ExplodeWithFirstRight((Pair)pair.Right, value);
        }

        /// <summary>
        /// Find first available regular number on left side of the tree (going backwards) and increase by value.
        /// If pair is found on left side first, use the forward function
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="value"></param>
        /// <param name="side"></param>
        public static void ExplodeWithRight(Pair pair, RegularNumber value, int side)
        {
            if (side == 1)
            {
                if (pair.side == 0) return;
                ExplodeWithRight((Pair)pair.parent, value, pair.side);
                return;
            }
            if (side == 2)
            {
                if (pair.Left.GetType() == typeof(RegularNumber))
                {
                    RegularNumber leftPair = (RegularNumber)pair.Left;
                    leftPair.Number += value.Number;
                    return;
                }
                ExplodeWithFirstRight((Pair)pair.Left, value);
                return;
            }
            return;
        }

        /// <summary>
        /// Find first available regular number on right side of the tree (going backwards) and increase by value.
        /// If pair is found on left side first, use the forward function
        /// </summary>
        /// <param name="pair"></param>
        /// <param name="value"></param>
        /// <param name="side"></param>
        public static void ExplodeWithLeft(Pair pair, RegularNumber value, int side)
        {
            if (side == 2)
            {
                if (pair.side == 0) return;
                ExplodeWithLeft((Pair)pair.parent, value, pair.side);
                return;
            }
            if (side == 1)
            {
                if (pair.Right.GetType() == typeof(RegularNumber))
                {
                    RegularNumber rightPair = (RegularNumber)pair.Right;
                    rightPair.Number += value.Number;
                    return;
                }
                ExplodeWithFirstLeft((Pair)pair.Right, value);
                return;
            }
            return;
        }

        /// <summary>
        /// Tries to explode first pair on the left... yay more recursion
        /// </summary>
        /// <param name="pair"></param>
        /// <returns></returns>
        public static bool TryExplodePair(Pair pair)
        {
            if (pair.IsRegular && pair.level >= 4)
            {
                ExplodeWithRight((Pair)pair.parent, (RegularNumber)pair.Left, pair.side);
                ExplodeWithLeft((Pair)pair.parent, (RegularNumber)pair.Right, pair.side);
                RegularNumber rn = new RegularNumber(0);
                rn.parent = pair.parent;
                rn.level = pair.level;
                rn.side = pair.side;
                if (pair.side == 1)
                {
                    ((Pair)pair.parent).Left = rn;
                }
                else
                {
                    ((Pair)pair.parent).Right = rn;
                }
                return true;
            }
            else
            {
                if (pair.Left.GetType() == typeof(Pair))
                {
                    if (TryExplodePair((Pair)pair.Left)) return true;
                }
                if (pair.Right.GetType() == typeof(Pair))
                {
                    if (TryExplodePair((Pair)pair.Right)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Finds end of pair
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static int FindEndPoint(string input)
        {
            int start = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '[')
                {
                    start++;
                }
                if (input[i] == ']')
                {
                    start--;
                }
                if (start == 0) return i;
            }
            return -1;
        }

        /// <summary>
        /// Parse string into a Snailfish number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static SnailfishNumber MakeNumber(string input)
        {
            SnailfishNumber leftNumber;
            SnailfishNumber rightNumber;
            int continuePoint = 0;
            if (input[1] == '[')
            {
                int leftEnd = FindEndPoint(input[1..]);
                string left = input.Substring(1, leftEnd + 1);
                leftNumber = MakeNumber(left);
                continuePoint = leftEnd + 3;
            }
            else
            {
                leftNumber = new RegularNumber(int.Parse(input.Substring(1, input.IndexOf(',') - 1)));
                continuePoint = input.IndexOf(',') + 1;
            }
            if (input[continuePoint] == '[')
            {
                int rightEnd = FindEndPoint(input[continuePoint..]);
                string right = input.Substring(continuePoint, rightEnd + 1);
                rightNumber = MakeNumber(right);
            }
            else
            {
                rightNumber = new RegularNumber(int.Parse(input.Substring(continuePoint, input.Length - continuePoint - 1)));
            }
            return new Pair(leftNumber, rightNumber);
        }

        /// <summary>
        /// Set metadata (side, level and parent) of snailfish number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="level"></param>
        private static void SetMetadata(SnailfishNumber number, int level)
        {
            number.level = level;
            if (number.GetType() == typeof(Pair))
            {
                Pair pair = (Pair)number;
                pair.Left.parent = number;
                pair.Left.side = 1;
                pair.Right.parent = number;
                pair.Right.side = 2;
                SetMetadata(pair.Left, level + 1);
                SetMetadata(pair.Right, level + 1);
            }
        }
    }
}