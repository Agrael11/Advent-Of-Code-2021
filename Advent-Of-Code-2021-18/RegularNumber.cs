namespace AdventOfCode.Day18
{
    public class RegularNumber : SnailfishNumber
    {
        public int Number;
        public new bool IsRegular { get { return true; } }


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