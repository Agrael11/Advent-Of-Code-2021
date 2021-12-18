namespace AdventOfCode.Day18
{
    public abstract class SnailfishNumber
    {
        public int level = 0;
        public SnailfishNumber parent = null;
        public int side = 0;
        public bool IsRegular { get { return false; } }

        public abstract int Magnitude();
    }
}