namespace AdventOfCode.Day19
{
    /// <summary>
    /// Main Class for Challange 2
    /// </summary>
    public static class Challange2
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static int DoChallange(string input)
        {
            //Parse Input Data
            input = input.Replace("\r", "").TrimEnd('\n');
            List<Scanner> scanners = new();

            foreach (string line in input.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("---"))
                {
                    scanners.Add(new Scanner(scanners.Count));
                    continue;
                }

                string[] vectorData = line.Split(',');
                Vector3 vector = new(int.Parse(vectorData[0]), int.Parse(vectorData[1]), int.Parse(vectorData[2]));
                scanners[^1].Beacons.Add(vector);
            }

            //Set first scanner as baked
            scanners[0].Baked = true;
            //Make list of scanners to be checked (in backwards order bcs will be removing from the list)
            List<int> notChecked = new();
            for (int i = scanners.Count - 1; i >= 0; i--)
            {
                notChecked.Add(i);
            }

            //Do until all scanners are not baked
            while (!AllBaked(scanners))
            {
                //for every scanner in list (backwards bcs removing)
                for (int ni = notChecked.Count - 1; ni >= 0; ni--)
                {
                    //If scanner is not baked, ignore
                    int i = notChecked[ni];
                    if (!scanners[i].Baked)
                        continue;
                    //remove scanner from list to be checked and compare it with eeevery known scanner
                    notChecked.RemoveAt(ni);
                    for (int j = 0; j < scanners.Count; j++)
                    {
                        //If the scanner is not baked and it's different scanner to first one check for overlaps
                        if (i == j)
                            continue;
                        if (scanners[j].Baked)
                            continue;
                        Task task = Scanner.FindMaxOverlaps(scanners[i], scanners[j]);
                        if (task.Status == TaskStatus.Running)
                            task.Wait();
                        if (AllBaked(scanners)) break;
                    }
                    if (AllBaked(scanners)) break;
                }
            }

            //Find highest manhattan distance between two scanners.
            int maxManhattan = 0;

            for (int scanner1 = 0; scanner1 < scanners.Count; scanner1++)
            {
                for (int scanner2 = 0; scanner2 < scanners.Count; scanner2++)
                {
                    if (scanner1 != scanner2)
                    {
                        int manhattan = (int)Math.Round(scanners[scanner1].RealPosition.ManhattanDistance(scanners[scanner2].RealPosition));
                        if (manhattan > maxManhattan)
                        {
                            maxManhattan = manhattan;
                        }
                    }
                }
            }

            return maxManhattan;
        }

        /// <summary>
        /// Check if all scanners are baked
        /// </summary>
        /// <param name="scanners"></param>
        /// <returns></returns>
        private static bool AllBaked(List<Scanner> scanners)
        {
            foreach (Scanner scanner in scanners)
            {
                if (!scanner.Baked) return false;
            }
            return true;
        }
    }
}