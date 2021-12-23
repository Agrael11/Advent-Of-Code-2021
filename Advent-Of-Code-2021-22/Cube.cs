namespace AdventOfCode.Day22
{
    /// <summary>
    /// 3D Cube class.
    /// </summary>
    public class Cube
    {
        public enum Direction { Forward, Backward, Left, Right, Up, Down };

        private Vector3 _position = Vector3.Zero;
        private Vector3 _secondCorner = Vector3.Zero;
        private Vector3 _size = Vector3.Zero; //This is automatically calculated, just so I don't have to do it every time.

        public Vector3 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                SecondCorner = Position + _size;
            }
        }
        public Vector3 SecondCorner
        {
            get { return _secondCorner; }
            set 
            {
                _secondCorner = value;
                _size = new Vector3(Math.Abs(SecondCorner.X - Position.X)+1, Math.Abs(SecondCorner.Y - Position.Y)+1, Math.Abs(SecondCorner.Z - Position.Z)+1);
            }
        }
        public Vector3 Size
        {
            get { return _size; }
        }
        public ulong Volume
        {
            get
            {
                return (ulong)Size.X * (ulong)Size.Y * (ulong)Size.Z;
            }
        }
        public static Cube Zero //Basic 0,0,0 -> 0,0,0 cube
        {
            get
            {
                return new Cube(Vector3.Zero, Vector3.Zero);
            }
        }

        public Cube(Vector3 position, Vector3 secondCorner)
        {
            Position = position;
            SecondCorner = secondCorner;
        }

        public static bool EqualOrContained(Cube inner, Cube outer) // If inner cube is exactly same OR is contained inside of outer cube
        {
            return (inner.Position.X >= outer.Position.X && inner.SecondCorner.X <= outer.SecondCorner.X &&
                inner.Position.Y >= outer.Position.Y && inner.SecondCorner.Y <= outer.SecondCorner.Y &&
                inner.Position.Z >= outer.Position.Z && inner.SecondCorner.Z <= outer.SecondCorner.Z);
        }

        public static bool Intersects(Cube cube1, Cube cube2) //Check if two cubes intersect
        {
            return (cube2.Position.X <= cube1.SecondCorner.X && cube2.SecondCorner.X >= cube1.Position.X &&
                cube2.Position.Y <= cube1.SecondCorner.Y && cube2.SecondCorner.Y >= cube1.Position.Y &&
                cube2.Position.Z <= cube1.SecondCorner.Z && cube2.SecondCorner.Z >= cube1.Position.Z);
        }
        public bool Intersects(Cube cube) => this.Intersects(cube);


        public static bool operator ==(Cube cubw1, Cube cube2)
        {
            return (cubw1.Size == cube2.Size && cubw1.Position == cube2.Position);
        }

        public static bool operator !=(Cube cube1, Cube cube2)
        {
            return (cube1.Size != cube2.Size || cube1.Position != cube2.Position);
        }

        public override bool Equals(object? obj)
        {
            if ((obj is null) || (obj.GetType() != typeof(Cube)))
                return false;
            Cube another = (Cube)obj;
            return (Size == another.Size && Position == another.Position);
        }

        public override int GetHashCode()
        {
            return Size.GetHashCode() + Position.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Position}->{SecondCorner} ({Size})";
        }
    }
}
