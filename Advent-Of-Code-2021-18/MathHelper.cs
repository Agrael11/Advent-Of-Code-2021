namespace AdventOfCode.Day18
{
    public static class MathHelper
    {
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
    }
}
