namespace AdventOfCode.Day12
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public class Challange1
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public int DoChallange(string inputData)
        {
            //Parse input into caves.
            //Note: Every startpoint is also endpoint of it's endpoint
            string[] input = inputData.Replace("\r", "").TrimEnd('\n').Split('\n');
            Dictionary<string, Cave> caves = new();
            foreach (string line in input)
            {
                string source = line.Split('-')[0];
                string target = line.Split('-')[1];
                if (caves.ContainsKey(source))
                {
                    caves[source].AddConnection(target);
                }
                else
                {
                    caves.Add(source, new Cave(source, target));
                }
                if (caves.ContainsKey(target))
                {
                    caves[target].AddConnection(source);
                }
                else
                {
                    caves.Add(target, new Cave(target, source));
                }
            }

            //Find all available paths
            List<List<string>> paths = FindPath("start", ref caves, null);

            //Return the result
            return paths.Count;
        }

        /// <summary>
        /// Finds all paths from input point towards "end" cave without repeating Visited small caves
        /// </summary>
        /// <param name="current"></param>
        /// <param name="caves"></param>
        /// <param name="Visited"></param>
        /// <returns></returns>
        private List<List<string>> FindPath(string current, ref Dictionary<string, Cave> caves, List<string>? Visited)
        {
            //If small cave, remember her as visited, also prepare output list
            if (Visited == null) Visited = new List<string>();
            if (!caves[current].Size) Visited.Add(current);
            List<List<string>> paths = new();

            //If "end", just list with it and nothing else.
            if (current == "end")
            {
                paths.Add(new List<string>() { "end" });
                return paths;
            }

            //Go trough every target for current cave and recursively check all ways of it
            //after doing that, put start point on their start and add them into already
            //known paths. That way we'll get every path from our point towards end.
            foreach (string target in caves[current].Connections)
            {
                if (!caves[target].Size && Visited.Contains(target)) continue;

                List<List<string>> newPaths = FindPath(target, ref caves, new List<string>(Visited));
                foreach (List<string> newPath in newPaths)
                {
                    newPath.Insert(0, current);
                }
                paths.AddRange(newPaths);
            }

            return paths;
         }
    }
}