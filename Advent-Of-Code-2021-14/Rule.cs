namespace AdventOfCode.Day14
{
    /// <summary>
    /// Represents one chemical rule.
    /// </summary>
    public struct Rule
    {
        public readonly string Origin;
        public readonly char Target;

        /// <summary>
        /// Creates one chemical rule
        /// </summary>
        /// <param name="origin">Original pair</param>
        /// <param name="target">Target to be added in between</param>
        public Rule(string origin, char target)
        {
            Origin = origin;
            Target = target;
        }

        public override string ToString()
        {
            string origin = "";
            for (int i = 0; i < Origin.Length; i++)
            {
                origin += Origin[i];
                if (i < Origin.Length - 1) origin += ';';
            }
            return $"[{origin}] -> [{Target}]";
        }
    }
}