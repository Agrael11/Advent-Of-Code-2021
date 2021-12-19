namespace AdventOfCode.Day19
{
    /// <summary>
    /// Main Class for Challange 1
    /// </summary>
    public static class Challange1
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

            //Make list of final beacons, containing beacons from first sensor for start
            sensors[0].Baked = true;
            List<Vector3> finalBeacons = new();
            finalBeacons.AddRange(sensors[0].Beacons);
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
                for (int ni = notChecked.Count-1; ni >= 0; ni--)
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
                        //If baked after finishing, add it's beacons into final list.
                        if (sensors[j].Baked)
                        {
                            foreach (Vector3 beacon in sensors[j].Beacons)
                            {
                                if (!finalBeacons.Contains(beacon))
                                {
                                    finalBeacons.Add(beacon);
                                }
                            }
                        }
                        if (AllBaked(sensors)) break;
                    }
                    if (AllBaked(sensors)) break;
                }
            }

            return finalBeacons.Count;
        }

        /// <summary>
        /// Check if all sensors are baked
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