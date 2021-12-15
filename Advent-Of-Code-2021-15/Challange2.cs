namespace AdventOfCode.Day15
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public class Challange2
    {
        private struct Node
        {
            public int X { get; set; }
            public int Y { get; set; }
            public byte Value { get; set; }
            public ulong Distance { get; set; }
            public bool Visited { get; set; } = false;
            public (int x, int y) Connected { get; set; } = (0, 0);

            public Node(int x, int y, byte value, uint distance)
            {
                X = x;
                Y = y;
                Value = value;
                Distance = distance;
            }
        }

        private Node[,] nodes = new Node[0, 0];
        private int Width { get { return nodes.GetLength(0); } }
        private int Height { get { return nodes.GetLength(1); } }
        private (int x, int y) current;
        private (int x, int y) target;

        private List<(int x, int y)> toCheck = new List<(int x, int y)>();

        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public ulong DoChallange(string input)
        {
            //Parse the input into set of chemical bonds (pairs) and rules.
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            nodes = new Node[inputData[0].Length * 5, inputData.Length * 5];
            current = (0, 0);
            toCheck.Add(current);
            target = (Width - 1, Height - 1);

            int originalWidth = inputData[0].Length;
            int originalHeight = inputData.Length;

            //Fill the tables
            for (int y = 0; y < originalWidth; y++)
            {
                for (int x = 0; x < originalHeight; x++)
                {
                    for (int copyY = 0; copyY < 5; copyY++)
                    { 
                        for (int copyX = 0; copyX < 5; copyX++)
                        {
                            int newX = x + copyX * originalWidth;
                            int newY = y + copyY * originalHeight;
                            int modifier = copyX + copyY;
                            byte newValue = (byte)((inputData[y][x] - '0') + modifier);
                            if (newValue > 9) newValue -= 9;
                            Node n = new(newX, newY, newValue, uint.MaxValue);
                            nodes[newX, newY] = n;
                        }
                    }
                }
            }

            nodes[0, 0].Distance = 0;
            nodes[0, 0].Connected = (-1, -1);

            //Check all cells until we're at finish.
            while (current != target)
            {
                CompareNodesAround();
                SelectNextCurrent();
            }


            return nodes[target.x, target.y].Distance;
        }

        /// <summary>
        /// Just here to debug -- Draws table
        /// </summary>
        private void DrawTable()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(nodes[x, y].Value);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Just here to debug -- Draws path trough table
        /// </summary>
        private void DrawPath()
        {
            int originalTop = Console.CursorTop;
            int originalLeft = Console.CursorLeft;
            Console.ForegroundColor = ConsoleColor.White;
            current = target;
            while (current != (-1, -1))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.CursorLeft = current.x;
                Console.CursorTop = current.y;
                Console.Write(nodes[current.x, current.y].Value);
                current = nodes[current.x, current.y].Connected;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.CursorLeft = originalLeft;
            Console.CursorTop = originalTop + 1;
        }

        /// <summary>
        /// Finds unvisited cell with lowest distance value to check next.
        /// </summary>
        private void SelectNextCurrent()
        {
            ulong smallest = ulong.MaxValue;
            (int x, int y) next = (0, 0);
            foreach ((int x, int y) check in toCheck)
            {
                if ((!nodes[check.x, check.y].Visited) && (nodes[check.x, check.y].Distance < smallest))
                {
                    next = (check.x, check.y);
                    smallest = nodes[check.x, check.y].Distance;
                }
            }
            current = (next.x, next.y);
        }

        /// <summary>
        /// Compares nodes around current node to find next target node.
        /// </summary>
        private void CompareNodesAround()
        {
            if (!nodes[current.x, current.y].Visited)
            {
                if (current.x > 0)
                {
                    int x = current.x - 1;
                    int y = current.y;
                    CheckNeighbour(x, y, current.x, current.y);
                }
                if (current.x < Width - 1)
                {
                    int x = current.x + 1;
                    int y = current.y;
                    CheckNeighbour(x, y, current.x, current.y);
                }
                if (current.y > 0)
                {
                    int x = current.x;
                    int y = current.y - 1;
                    CheckNeighbour(x, y, current.x, current.y);
                }
                if (current.y < Height - 1)
                {
                    int x = current.x;
                    int y = current.y + 1;
                    CheckNeighbour(x, y, current.x, current.y);
                }
                nodes[current.x, current.y].Visited = true;
                toCheck.Remove(current);
            }
        }

        /// <summary>
        /// Compares selected neighbour cell to current cell
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="originalX"></param>
        /// <param name="originalY"></param>
        private void CheckNeighbour(int x, int y, int originalX, int originalY)
        {
            if (nodes[x, y].Visited)
                return;
            ulong newDistance = nodes[originalX, originalY].Distance + nodes[x, y].Value;
            if (newDistance < nodes[x, y].Distance)
            {
                nodes[x, y].Distance = newDistance;
                nodes[x, y].Connected = (originalX, originalY);
                if (!toCheck.Contains((x, y))) toCheck.Add((x, y));
            }
        }
    }
}