namespace AdventOfCode.Day08
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public class Challange2
    {
        //Order in which numbers will be checked
        private static ushort[] _checkOrderList = { 1, 7, 4, 3, 5, 2, 8, 0, 6, 9 };

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public int DoChallange(string input)
        {
            //Define total (as starting value 0) and go trough every line of input
            int total = 0;

            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');
            foreach (string currentInput in inputData)
            {
                //Define arrays storing information about known numerals, and segments, and fill segments with all possiblities.
                string[] numerals = new string[10];
                string[] segments = new string[7];
                SetSegments("abcdefg", ref segments, 0, 1, 2, 3, 4, 5, 6);

                //Split input data into information about numerals 0-9 (in random order, yay) on left side, and output numerals on right side, divided by " | "
                List<string> numeralsInfo = currentInput.Split(" | ")[0].Split(' ').ToList();
                string outputInfo = currentInput.Split(" | ")[1];

                //Identify numerals, attach them into "numerals" array on correct position, remove them from input list AND extrapolate segment info from them
                //Numerals are in order 1,7,4,3 and 5, as I found it's easiest way to correctly identify all segments and numerals.
                //Order is deifnited in check order list.
                for (int order = 0; order < _checkOrderList.Length; order++)
                {
                    IdentifyAndProcessNumeral(_checkOrderList[order], ref numeralsInfo, ref numerals, ref segments);
                }

                int value = 0;
                for (int valueIndex = 0; valueIndex < 4; valueIndex++)
                {
                    string outputNumeral = outputInfo.Split(' ')[valueIndex];
                    for (int numeral = 0; numeral < 10; numeral++)
                    {
                        if (CompareStringsRandomOrder(outputNumeral, numerals[numeral]))
                        {
                            value += numeral * (int)Math.Pow(10, 3 - valueIndex);
                        }
                    }
                }
                //Add this 4 digit number into total
                total += value;
            }

            //Return the result
            return total;
        }


    /// <summary>
    /// Compares two strings, not caring about order of characters. Since characters will never repeat, this is simple enough.
    /// </summary>
    /// <param name="str1"></param>
    /// <param name="str2"></param>
    /// <returns></returns>
    private static bool CompareStringsRandomOrder(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;

            for (int i = 0; i < str1.Length; i++)
            {
                if (!str2.Contains(str1[i])) return false;
            }
            return true;
        }

        /// <summary>
        /// Removes characters from specified segments
        /// </summary>
        /// <param name="toRemove"></param>
        /// <param name="segments"></param>
        /// <param name="segmentsList"></param>
        private static void RemoveFromSegments(string toRemove, ref string[] segments, params int[] segmentsList)
        {
            foreach (int segment in segmentsList)
            {
                foreach (char c in toRemove)
                {
                    segments[segment] = segments[segment].Replace(c.ToString(), "");
                }
            }
        }

        /// <summary>
        /// Sets specified segments to value
        /// </summary>
        /// <param name="toRemove"></param>
        /// <param name="segments"></param>
        /// <param name="segmentsList"></param>
        private static void SetSegments(string toSet, ref string[] segments, params int[] segmentsList)
        {
            foreach (int segment in segmentsList)
            {
                segments[segment] = toSet;
            }
        }

        /// <summary>
        /// Keep only specifed letters in specified segment
        /// </summary>
        /// <param name="toSet"></param>
        /// <param name="segments"></param>
        /// <param name="segmentsList"></param>
        private static void SetSegmentsAnd(string toSet, ref string[] segments, params int[] segmentsList)
        {
            foreach (int segment in segmentsList)
            {
                string newSegment = "";
                foreach (char c in toSet)
                {
                    if (segments[segment].Contains(c))
                    {
                        newSegment += c;
                    }
                }
                segments[segment] = newSegment;
            }
        }

        /// <summary>
        /// Just selects correct function per numeral, so I don't have to call different function every time in main.
        /// Not very optimal, but in this case I preffer it for readability
        /// </summary>
        /// <param name="numeral"></param>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcessNumeral(ushort numeral, ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            switch (numeral)
            {
                case 0:
                    IdentifyAndProcess0(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 1:
                    IdentifyAndProcess1(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 2:
                    IdentifyAndProcess2(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 3:
                    IdentifyAndProcess3(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 4:
                    IdentifyAndProcess4(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 5:
                    IdentifyAndProcess5(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 6:
                    IdentifyAndProcess6(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 7:
                    IdentifyAndProcess7(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 8:
                    IdentifyAndProcess8(ref numeralsInfo, ref numerals, ref segments);
                    break;
                case 9:
                    IdentifyAndProcess9(ref numeralsInfo, ref numerals, ref segments);
                    break;
            }
        }


        /// <summary>
        /// Checks if numerals is 0, adds it into correct slot in numeral list and removes it from input list
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess0(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 6) continue;

                if (!(numeral.Contains(segments[0][0])
                    && numeral.Contains(segments[1][0])
                    && numeral.Contains(segments[2][0])
                    && numeral.Contains(segments[4][0])
                    && numeral.Contains(segments[5][0])
                    && numeral.Contains(segments[6][0]))) continue;

                numerals[0] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 1, adds it into correct slot in numeral list and removes it from input list and sets segments to correct values.
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess1(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 2) continue;

                SetSegmentsAnd(numeral, ref segments, 2, 5);
                RemoveFromSegments(numeral, ref segments, 0, 1, 3, 4, 6);
                numerals[1] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 2, adds it into correct slot in numeral list and removes it from input list
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess2(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 5) continue;

                numerals[2] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 3, adds it into correct slot in numeral list and removes it from input list and sets segments to correct values.
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess3(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 5) continue;

                if (!(numeral.Contains(segments[2][0])
                    && numeral.Contains(segments[2][1])
                    && numeral.Contains(segments[0][0]))) continue;

                SetSegmentsAnd(numeral, ref segments, 0, 2, 3, 5, 6);
                RemoveFromSegments(numeral, ref segments, 1, 4);
                numerals[3] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 4, adds it into correct slot in numeral list and removes it from input list and sets segments to correct values.
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess4(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 4) continue;

                SetSegmentsAnd(numeral, ref segments, 1, 2, 3, 5);
                RemoveFromSegments(numeral, ref segments, 0, 4, 6);
                numerals[4] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 5, adds it into correct slot in numeral list and removes it from input list and sets segments to correct values.
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess5(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 5) continue;

                if (!(numeral.Contains(segments[0][0])
                    && numeral.Contains(segments[1][0])
                    && numeral.Contains(segments[3][0])
                    && numeral.Contains(segments[6][0]))) continue;

                SetSegmentsAnd(numeral, ref segments, 0, 1, 3, 5, 6);
                RemoveFromSegments(numeral, ref segments, 2, 4);
                numerals[5] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 6, adds it into correct slot in numeral list and removes it from input list
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess6(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 6) continue;

                if (!(numeral.Contains(segments[0][0])
                    && numeral.Contains(segments[1][0])
                    && numeral.Contains(segments[3][0])
                    && numeral.Contains(segments[4][0])
                    && numeral.Contains(segments[5][0])
                    && numeral.Contains(segments[6][0]))) continue;

                numerals[6] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 7, adds it into correct slot in numeral list and removes it from input list and sets segments to correct values.
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess7(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 3) continue;

                SetSegmentsAnd(numeral, ref segments, 0, 2, 5);
                RemoveFromSegments(numeral, ref segments, 1, 3, 4, 6);
                numerals[7] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 8, adds it into correct slot in numeral list and removes it from input list
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess8(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 7) continue;

                numerals[8] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }

        /// <summary>
        /// Checks if numerals is 9, adds it into correct slot in numeral list and removes it from input list
        /// </summary>
        /// <param name="numeralsInfo"></param>
        /// <param name="numerals"></param>
        /// <param name="segments"></param>
        private static void IdentifyAndProcess9(ref List<string> numeralsInfo, ref string[] numerals, ref string[] segments)
        {
            foreach (string numeral in numeralsInfo)
            {
                if (numeral.Length != 6) continue;

                if (!(numeral.Contains(segments[0][0])
                    && numeral.Contains(segments[1][0])
                    && numeral.Contains(segments[2][0])
                    && numeral.Contains(segments[3][0])
                    && numeral.Contains(segments[5][0])
                    && numeral.Contains(segments[6][0]))) continue;

                numerals[9] = numeral;
                numeralsInfo.Remove(numeral);
                break;
            }
        }
    }
}