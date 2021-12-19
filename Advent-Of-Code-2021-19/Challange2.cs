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
            List<Scanner> sensors = new();

            foreach (string line in input.Split('\n'))
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                if (line.StartsWith("---"))
                {
                    sensors.Add(new Scanner(sensors.Count));
                    continue;
                }

                string[] vectorData = line.Split(',');
                Vector3 vector = new(int.Parse(vectorData[0]), int.Parse(vectorData[1]), int.Parse(vectorData[2]));
                sensors[^1].Beacons.Add(vector);
            }

            //Set first sensor as baked
            sensors[0].Baked = true;
            //Make list of sensors to be checked (in backwards order bcs will be removing from the list)
            List<int> notChecked = new();
            for (int i = sensors.Count - 1; i >= 0; i--)
            {
                notChecked.Add(i);
            }

            //Do until all sensors are not baked
            while (!AllBaked(sensors))
            {
                //for every sensor in list (backwards bcs removing)
                for (int ni = notChecked.Count - 1; ni >= 0; ni--)
                {
                    //If sensor is not baked, ignore
                    int i = notChecked[ni];
                    if (!sensors[i].Baked)
                        continue;
                    //remove sensor from list to be checked and compare it with eeevery known sensor
                    notChecked.RemoveAt(ni);
                    for (int j = 0; j < sensors.Count; j++)
                    {
                        //If the sensor is not baked and it's different sensor to first one check for overlaps
                        if (i == j)
                            continue;
                        if (sensors[j].Baked)
                            continue;
                        Scanner.FindMaxOverlaps(sensors[i], sensors[j]);
                        if (AllBaked(sensors)) break;
                    }
                    if (AllBaked(sensors)) break;
                }
            }

            //Find highest manhattan distance between two sensors.
            int maxManhattan = 0;

            for (int sensor1 = 0; sensor1 < sensors.Count; sensor1++)
            {
                for (int sensor2 = 0; sensor2 < sensors.Count; sensor2++)
                {
                    if (sensor1 != sensor2)
                    {
                        int manhattan = (int)Math.Round(sensors[sensor1].RealPosition.ManhattanDistance(sensors[sensor2].RealPosition));
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
        /// <param name="sensors"></param>
        /// <returns></returns>
        private static bool AllBaked(List<Scanner> sensors)
        {
            foreach (Scanner sensor in sensors)
            {
                if (!sensor.Baked) return false;
            }
            return true;
        }
    }
}