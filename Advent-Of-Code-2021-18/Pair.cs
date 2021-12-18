namespace AdventOfCode.Day18
{
    public class Pair : SnailfishNumber
    {
        public SnailfishNumber Left;
        public SnailfishNumber Right;
        public new bool IsRegular { get { return (Left.GetType() == Right.GetType() && Left.GetType() == typeof(RegularNumber)); } }

        public Pair(SnailfishNumber left, SnailfishNumber right)
        {
            Left = left;
            Right = right;
        }


        public override int Magnitude()
        {
            return Left.Magnitude() * 3 + Right.Magnitude() * 2;
        }

        public override string ToString()
        {
            return $"[{Left},{Right}]";
        }
    }
}