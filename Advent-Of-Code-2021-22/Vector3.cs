namespace AdventOfCode.Day22
{
    /// <summary>
    /// 3D Vector class.
    /// </summary>
    public class Vector3
    {
        public enum Direction {Forward, Backward, Left, Right, Up, Down};

        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }
        public double Length
        {
            get 
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }

        public Vector3(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{{{X};{Y},{Z}}}";
        }

        /// <summary>
        /// Makes a clone of Vector
        /// </summary>
        /// <returns></returns>
        public Vector3 Clone()
        {
            return new Vector3(X, Y, Z);
        }

        public static Vector3 operator +(Vector3 vector3a, Vector3 vector3b)
        {
            return new Vector3(vector3a.X + vector3b.X, vector3a.Y + vector3b.Y, vector3a.Z + vector3b.Z);
        }

        public static Vector3 operator -(Vector3 vector3a, Vector3 vector3b)
        {
            return new Vector3(vector3a.X - vector3b.X, vector3a.Y - vector3b.Y, vector3a.Z - vector3b.Z);
        }

        public static bool operator ==(Vector3 vector3a, Vector3 vector3b)
        {
            return (vector3a.X == vector3b.X) && (vector3a.Y == vector3b.Y) && (vector3a.Z == vector3b.Z);
        }

        public static bool operator !=(Vector3 vector3a, Vector3 vector3b)
        {
            return (vector3a.X != vector3b.X) || (vector3a.Y != vector3b.Y) || (vector3a.Z != vector3b.Z);
        }

        public override bool Equals(object? obj)
        {
            if ((obj is null) || (obj.GetType() != typeof(Vector3)))
                return false;
            Vector3 another = (Vector3)obj;
            Vector3 me = this;
            return (me.X == another.X && me.Y == another.Y && me.Z == another.Z);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
    }
}
