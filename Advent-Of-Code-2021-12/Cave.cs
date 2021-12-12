
namespace AdventOfCode.Day12
{
    public struct Cave
    {
        public string Name;
        public bool Size;
        public List<string> Connections;

        public Cave(string name, string firstTarget)
        {
            Name = name;
            Size = (Char.IsUpper(name[0]));
            Connections = new() { firstTarget };
        }

        public void AddConnection(string connection)
        {
            if (Connections.Contains(connection)) return;
            Connections.Add(connection);
        }
    }
}