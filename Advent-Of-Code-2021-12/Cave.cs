
namespace AdventOfCode.Day12
{
    public struct Cave
    {
        public string Name { get; set; }
        public bool Size { get; set; }
        public List<string> Connections { get; }

        public Cave(string name, string firstTarget)
        {
            Name = name;
            Size = char.IsUpper(name[0]);
            Connections = new() { firstTarget };
        }

        public void AddConnection(string connection)
        {
            if (Connections.Contains(connection)) return;
            Connections.Add(connection);
        }
    }
}