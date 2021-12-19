namespace AdventOfCode.Day19
{
    /// <summary>
    /// 3D Vector class.
    /// </summary>
    public class Vector3
    {
        public enum Direction {Forward, Backward, Left, Right, Up, Down};

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Length
        {
            get 
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{{{X:0.##};{Y:0.##};{Z:0.##}}}";
        }

        /// <summary>
        /// Makes a clone of Vector
        /// </summary>
        /// <returns></returns>
        public Vector3 Clone()
        {
            return new Vector3(X, Y, Z);
        }

        /// <summary>
        /// Get cross product of vectors
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public Vector3 Cross(Vector3 vector3)
        {
            return new Vector3(Y * vector3.Z - Z * vector3.Y, -X * vector3.Z + Z * vector3.X, X * vector3.Y - Y * vector3.X);
        }
        /// <summary>
        /// Get cross product of vectors
        /// </summary>
        /// <param name="vector3a"></param>
        /// <param name="vector3b"></param>
        /// <returns></returns>
        public static Vector3 Cross(Vector3 vector3a, Vector3 vector3b) => vector3a.Cross(vector3b);

        /// <summary>
        /// Normalize a vector
        /// </summary>
        public void Normalize()
        {
            var div = 1 / Length;
            X *= div;
            Y *= div;
            Z *= div;
        }
        /// <summary>
        /// Normalize a vector
        /// </summary>
        /// <param name="vector3"></param>
        public static void Normalize(Vector3 vector3) => vector3.Normalize();

        /// <summary>
        /// Gets Manhattan Distance (or at least that's what advent of code called it) between two Vectors
        /// </summary>
        /// <param name="vector3"></param>
        /// <returns></returns>
        public double ManhattanDistance(Vector3 vector3)
        {
            double x = X - vector3.X;
            double y = Y - vector3.Y;
            double z = Z - vector3.Z;
            return Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
        }
        public static double ManhattanDistance(Vector3 vector3a, Vector3 vector3b) => vector3a.ManhattanDistance(vector3b);

        /// <summary>
        /// Rotates Vector around Axis at angle
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public Vector3 Rotate(Vector3 axis, double angle)
        {
            Vector3 vxp = axis.Cross(this);
            Vector3 vxvxp = axis.Cross(vxp);
            return this + Math.Sin(angle) * vxp + (1 - Math.Cos(angle)) * vxvxp;
        }

        /// <summary>
        /// Rotates vectors towards a "forward" direction, setting it's up direction
        /// </summary>
        /// <param name="forward"></param>
        /// <param name="up"></param>
        /// <returns></returns>
        public Vector3 Rotate(Direction forward, Direction up)
        {
            switch (forward)
            {
                case Direction.Forward:
                    {
                        switch (up)
                        {
                            case Direction.Up:
                                return Clone();
                            case Direction.Right:
                                return Rotate(new Vector3(1, 0, 0), Math.PI * 0.5);
                            case Direction.Down:
                                return Rotate(new Vector3(1, 0, 0), Math.PI);
                            case Direction.Left:
                                return Rotate(new Vector3(1, 0, 0), Math.PI * 1.5);
                        }
                        break;
                    }
                case Direction.Up:
                    {
                        Vector3 newVector = Rotate(new Vector3(0, 1, 0), Math.PI * 0.5);
                        switch (up)
                        {
                            case Direction.Backward:
                                return newVector;
                            case Direction.Left:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI * 0.5);
                            case Direction.Forward:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI);
                            case Direction.Right:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI * 1.5);
                        }
                        break;
                    }
                case Direction.Backward:
                    {
                        Vector3 newVector = Rotate(new Vector3(0, 1, 0), Math.PI);
                        switch (up)
                        {
                            case Direction.Down:
                                return newVector;
                            case Direction.Left:
                                return newVector.Rotate(new Vector3(1, 0, 0), Math.PI * 0.5);
                            case Direction.Up:
                                return newVector.Rotate(new Vector3(1, 0, 0), Math.PI);
                            case Direction.Right:
                                return newVector.Rotate(new Vector3(1, 0, 0), Math.PI * 1.5);
                        }
                        break;
                    }
                case Direction.Down:
                    {
                        Vector3 newVector = Rotate(new Vector3(0, 1, 0), Math.PI * 1.5);
                        switch (up)
                        {
                            case Direction.Forward:
                                return newVector;
                            case Direction.Right:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI * 0.5);
                            case Direction.Backward:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI);
                            case Direction.Left:
                                return newVector.Rotate(new Vector3(0, 0, 1), Math.PI * 1.5);
                        }
                        break;
                    }
                case Direction.Right:
                    {
                        Vector3 newVector = Rotate(new Vector3(0, 0, 1), Math.PI * 0.5);
                        switch (up)
                        {
                            case Direction.Up:
                                return newVector;
                            case Direction.Forward:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI * 0.5);
                            case Direction.Down:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI);
                            case Direction.Backward:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI * 1.5);

                        }
                        break;
                    }
                case Direction.Left:
                    {
                        Vector3 newVector = Rotate(new Vector3(0, 0, 1), Math.PI * 1.5);
                        switch (up)
                        {
                            case Direction.Up:
                                return newVector;
                            case Direction.Backward:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI * 0.5);
                            case Direction.Down:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI);
                            case Direction.Forward:
                                return newVector.Rotate(new Vector3(0, 1, 0), Math.PI * 1.5);

                        }
                        break;
                    }
            }
            return Zero;
        }

        public static Vector3 operator +(Vector3 vector3a, Vector3 vector3b)
        {
            return new Vector3(vector3a.X + vector3b.X, vector3a.Y + vector3b.Y, vector3a.Z + vector3b.Z);
        }
        public static Vector3 operator -(Vector3 vector3a, Vector3 vector3b)
        {
            return new Vector3(vector3a.X - vector3b.X, vector3a.Y - vector3b.Y, vector3a.Z - vector3b.Z);
        }
        public static Vector3 operator *(double scale, Vector3 vector3)
        {
            return new Vector3(scale * vector3.X, scale * vector3.Y, scale * vector3.Z);
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
            Vector3i another = (Vector3)obj;
            Vector3i me = this;
            return (me.X == another.X && me.Y == another.Y && me.Z == another.Z);
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode();
        }
    }
}
