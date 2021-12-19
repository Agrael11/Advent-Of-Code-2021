using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day19
{
    /// <summary>
    /// One scanner
    /// </summary>
    public class Scanner
    {
        public List<Vector3> Beacons { get; private set; } = new ();
        public Vector3 Position = Vector3.Zero;
        public Vector3 RealPosition = Vector3.Zero;
        public (Vector3.Direction forward, Vector3.Direction up) Rotation = (Vector3.Direction.Forward, Vector3.Direction.Up);
        public bool Baked { get; set; }

        public int ID { get; set; }

        public Scanner(int id)
        {
            ID = id;
        }

        /// <summary>
        /// Gets beacon at index, translated by current rotation and position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Vector3 GetTranslatedBeacon(int index)
        {
            Vector3 beacon = Beacons[index].Clone();

            beacon = beacon.Rotate(Rotation.forward, Rotation.up);
            beacon -= Position;

            return beacon;
        }

        /// <summary>
        /// Bakes rotation and position into current list of beacons.
        /// </summary>
        public void BakeTranslation()
        {
            Beacons = TranslatedBeacons;
            RealPosition = Position;
            Position = Vector3.Zero;
            Rotation = (Vector3.Direction.Forward, Vector3.Direction.Up);
            Baked = true;
        }

        /// <summary>
        /// Gets list of all beacons, translated by current rotation and position
        /// </summary>
        public List<Vector3> TranslatedBeacons
        {
            get
            {
                List<Vector3> newBeacons = new();
                for (int i = 0; i < Beacons.Count; i++)
                {
                    newBeacons.Add(GetTranslatedBeacon(i));
                }
                return newBeacons;
            }
        }

        /// <summary>
        /// Find overlapping beacons between two sensors, with various rotations and position shifts
        /// If at least 12 overlaps happen, bake position and rotation into second sensor.
        /// Return amount of overlaps (unnecessary, but nice for debugging)
        /// 
        /// This is slow and sad
        /// </summary>
        /// <param name="sensor1"></param>
        /// <param name="sensor2"></param>
        /// <returns></returns>
        public static int FindMaxOverlaps(Scanner sensor1, Scanner sensor2)
        {
            int maxOverlaps = 0;
            Vector3 position = Vector3.Zero;
            Scanner sensor = new(-1);
            (Vector3.Direction forward, Vector3.Direction up) direction =(Vector3.Direction.Up, Vector3.Direction.Up);

            foreach (Vector3 beacon in sensor1.Beacons)
            {
                foreach (Vector3.Direction forward in Enum.GetValues(typeof(Vector3.Direction)))
                {
                    foreach (Vector3.Direction up in Enum.GetValues(typeof(Vector3.Direction)))
                    {
                        switch (forward)
                            {
                                case Vector3.Direction.Forward:
                                case Vector3.Direction.Backward:
                                    if (up == Vector3.Direction.Forward || up == Vector3.Direction.Backward)
                                        continue;
                                    break;
                                case Vector3.Direction.Up:
                                case Vector3.Direction.Down:
                                    if (up == Vector3.Direction.Up || up == Vector3.Direction.Down)
                                        continue;
                                    break;
                                case Vector3.Direction.Left:
                                case Vector3.Direction.Right:
                                    if (up == Vector3.Direction.Left || up == Vector3.Direction.Right)
                                        continue;
                                    break;
                        }
                        sensor2.Position = Vector3.Zero;
                        sensor2.Rotation = (forward, up);
                        List<Vector3> translatedOther = sensor2.TranslatedBeacons;
                        List<int> checkedList = new();
                        for (int otherBeacon = 0; otherBeacon < translatedOther.Count; otherBeacon++)
                        {
                            if (checkedList.Contains(otherBeacon))
                                continue;
                            Vector3 offset = translatedOther[otherBeacon] - beacon;
                            sensor2.Position = offset;
                            int overlaps = 0;
                            List<Vector3> translatedNew = sensor2.TranslatedBeacons;
                            foreach (Vector3 originalBeacon in sensor1.Beacons)
                            {
                                for (int newOther = 0; newOther < translatedNew.Count; newOther++)
                                {
                                    if (originalBeacon.Equals(translatedNew[newOther]))
                                    {
                                        if (!checkedList.Contains(newOther))
                                            checkedList.Add(newOther);
                                        overlaps++;
                                    }
                                }
                            }
                            if (overlaps > maxOverlaps)
                            {
                                maxOverlaps = overlaps;
                                sensor = sensor2;
                                position = sensor2.Position;
                                direction = sensor2.Rotation;
                            }
                        }
                    }
                }
            }

            if (maxOverlaps >= 12)
            {
                sensor.Position = position;
                sensor.Rotation = direction;
                sensor.BakeTranslation();
            }

            return maxOverlaps;
        }
    }
}
