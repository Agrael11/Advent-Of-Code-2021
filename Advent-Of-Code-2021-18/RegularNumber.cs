namespace AdventOfCode.Day18
{
    public class RegularNumber : SnailfishNumber
    {
        public int Number;
#pragma warning disable CA1822 // Mark members as static
        public new bool IsRegular => true;
#pragma warning restore CA1822 // Mark members as static


        public RegularNumber(int number)
        {
            Number = number;
        }

        public override int Magnitude()
        {
            return Number;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }
}