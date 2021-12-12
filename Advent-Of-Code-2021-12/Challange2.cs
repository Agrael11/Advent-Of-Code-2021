using System;
using System.IO;

namespace AdventOfCode.Day12
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public class Challange2
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public ulong DoChallange(string inputData)
        {
            //Parse input into caves.
            //Note: Every startpoint is also endpoint of it's endpoint
            string[] input = inputData.Replace("\r", "").TrimEnd('\n').Split('\n');
            SortedDictionary<string, Cave> caves = new();
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

            foreach (Cave cave in caves.Values)
            {
                cave.Connections.Sort();
            }

            //Find count of all available paths
            ulong paths = FindPath("start", ref caves, null);

            //Write (and return) their amount.
            Console.WriteLine($"There is {paths} possible paths.");

            return paths;
        }

        /// <summary>
        /// Finds all paths from input point towards "end" cave without repeating Visited small caves
        /// </summary>
        /// <param name="current"></param>
        /// <param name="caves"></param>
        /// <param name="Visited"></param>
        /// <returns></returns>
        private ulong FindPath(string current, ref SortedDictionary<string, Cave> caves, Dictionary<string, bool>? Visited, bool doublevisit = false)
        {
            //If "end", just list with it and nothing else.
            if (current == "end")
            {
                //Console.WriteLine();
                return 1;
            }

            //If small cave, if already visited, count doublevisit, else remember her as visited
            if (Visited == null) Visited = new();
            if (!caves[current].Size)
            {
                if (Visited.ContainsKey(current))
                {
                    Visited[current] = true;
                    doublevisit = true;
                }
                else
                {
                    Visited.Add(current, false);
                }
            }
            ulong paths = 0;

            //Go trough every target for current cave and recursively check all ways of it
            //after doing that, put start point on their start and add them into already
            //known paths. That way we'll get every path from our point towards end.
            //If we already visited target twice, ignore.
            foreach (string target in caves[current].Connections)
            {
                if (!caves[target].Size && ((Visited.ContainsKey(target) && doublevisit) || target == "start"))
                    continue;

                //Console.Write(target + ",");
                paths += FindPath(target, ref caves, Visited, doublevisit); ;
            }
            if (Visited.ContainsKey(current))
            {
                if (Visited[current]) Visited[current] = false;
                else Visited.Remove(current);
            }
            //Console.Write(current + "<,");
            return paths;
         }
    }
}