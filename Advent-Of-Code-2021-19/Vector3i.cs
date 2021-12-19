using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day19
{
    /// <summary>
    /// Just a helper class with Integer Vector3, that has implicit coversion from and to Double version of Vector3...
    /// </summary>
    public class Vector3i
    {
        public enum Direction {Forward, Backward, Left, Right, Up, Down};

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public double Length
        {
            get 
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3i Zero { get { return new Vector3i(0, 0, 0); } }

        public Vector3i(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{{{X};{Y};{Z}}}";
        }

        public static implicit operator Vector3(Vector3i original) => new(original.X, original.Y, original.Z);
        public static implicit operator Vector3i(Vector3 original) => new((int)Math.Round(original.X), (int)Math.Round(original.Y), (int)Math.Round(original.Z));
    }
}
