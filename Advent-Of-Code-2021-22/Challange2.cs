namespace AdventOfCode.Day22
{
    /// <summary>
    /// Main Class for Challange 2 -- Thanks u/Deynai for help!
    /// </summary>
    public static class Challange2
    {
        /// <summary>
        /// This is the Main function
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static ulong DoChallange(string input)
        {
            //Parse Input Data
            string[] inputData = input.Replace("\r", "").TrimEnd('\n').Split('\n');

            List<InstructionInfo> instructions = new();

            List<Cube> cubes = new();

            foreach (string line in inputData)
            {
                string instruction = line.Split(' ')[0];
                string[] data = line.Split(' ')[1].Split(',');
                long xStart = long.Parse(data[0].Split('=')[1].Split("..")[0]);
                long xEnd = long.Parse(data[0].Split('=')[1].Split("..")[1]);
                long yStart = long.Parse(data[1].Split('=')[1].Split("..")[0]);
                long yEnd = long.Parse(data[1].Split('=')[1].Split("..")[1]);
                long zStart = long.Parse(data[2].Split('=')[1].Split("..")[0]);
                long zEnd = long.Parse(data[2].Split('=')[1].Split("..")[1]);
                Vector3 position = new(xStart, yStart, zStart);
                Vector3 secondPoint = new(xEnd, yEnd, zEnd);
                Cube cube = new(position, secondPoint);
                InstructionInfo info = new((instruction == "on"), cube);
                instructions.Add(info);
            }

            foreach (InstructionInfo info in instructions)
            {
                if (cubes.Count == 0 && info.Instruction)
                {
                    cubes.Add(info.Cube);
                    continue;
                }

                List<Cube> instructionCubes = new() { info.Cube };
                List<Cube> newCubes = new();

                //If instruction is to add box
                if (info.Instruction)
                {
                    while (instructionCubes.Count > 0) //Until there are any cubes to add (we're replacing one cube with many)
                    {
                        foreach (Cube instructionCube in instructionCubes)
                        {
                            bool stop = false;
                            if (cubes.Count == 0) //If there are no cubes, just add it. it doesn't intersect with anything
                            {
                                cubes.Add(instructionCube);
                                instructionCubes.Remove(instructionCube);
                                break;
                            }
                            foreach (Cube originalCube in cubes) //Check if cube is equal or inside another cube. if it's inside, just remove it from list
                            {
                                if (Cube.EqualOrContained(instructionCube, originalCube))
                                {
                                    instructionCubes.Remove(instructionCube);
                                    stop = true;
                                    break;
                                }
                            }
                            if (stop) //IMPORTANT! DON'T CHECK FOR INTERSECTIONS IF WE REMOVED THE INSTRUCTION CUBE ALREADY!
                            {
                                break;
                            }
                            foreach (Cube originalCube in cubes) //Check if cube intersects, if yes, divide it
                            {
                                if (Cube.Intersects(instructionCube, originalCube))
                                {
                                    Cube[] newNewCubes = SplitCube(instructionCube, originalCube);
                                    instructionCubes.Remove(instructionCube);
                                    instructionCubes.AddRange(newNewCubes);
                                    stop = true;
                                    break;
                                }
                            }
                            if (stop)
                            {
                                break;
                            }
                            //If not intersecting with enything, it's possible to add it to list
                            newCubes.Add(instructionCube);
                            instructionCubes.Remove(instructionCube);
                            break;
                        }
                    }
                    cubes.AddRange(newCubes);
                }
                else //If subtratction
                {
                    while (instructionCubes.Count > 0)
                    {
                        foreach (Cube instructionCube in instructionCubes)
                        {
                            bool stop = false;
                            if (cubes.Count == 0) //If no cube in list, there's nothing to remove from, so ignore this one
                            {
                                instructionCubes.Remove(instructionCube);
                                break;
                            }
                            foreach (Cube originalCube in cubes) //Check if it's same as another cube, if yes remove both
                            {
                                if (instructionCube == originalCube)
                                {
                                    cubes.Remove(instructionCube);
                                    instructionCubes.Remove(instructionCube);
                                    stop = true;
                                    break;
                                }
                            }
                            if (stop) //IMPORTANT! DON'T CHECK FOR INTERSECTIONS IF WE REMOVED THE INSTRUCTION CUBE ALREADY!
                            {
                                break;
                            }
                            foreach (Cube originalCube in cubes) //Check if instersect, if yes, split both cubes
                            {
                                if (Cube.Intersects(instructionCube, originalCube))
                                {
                                    Cube[] oldCubes = SplitCube(originalCube, instructionCube);
                                    Cube[] newNewCubes = SplitCube(instructionCube, originalCube);
                                    instructionCubes.Remove(instructionCube);
                                    instructionCubes.AddRange(newNewCubes);
                                    cubes.Remove(originalCube);
                                    cubes.AddRange(oldCubes);
                                    stop = true;
                                    break;
                                }
                            }
                            if (stop)
                            {
                                break;
                            }
                            //If not found, it's not intersecting with anything so nothing to remove
                            instructionCubes.Remove(instructionCube);
                            break;
                        }
                    }
                }
            }

            ulong size = 0;
            foreach (Cube cube in cubes)
            {
                size += cube.Volume;
            }

            return size;
        }

        /// <summary>
        /// Splits cube into multiple cubes (1, 2, 4 or 8) by second cube
        /// </summary>
        /// <param name="originalCube"></param>
        /// <param name="secondCube"></param>
        /// <returns></returns>
        public static Cube[] SplitCube(Cube originalCube, Cube secondCube)
        {
            List<Cube> cubes = new();
            cubes.Add(originalCube);

            List<Cube> newCubes = new();
            //X split
            foreach (Cube cube in cubes)
            {
                if (secondCube.Position.X > cube.Position.X)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(secondCube.Position.X - 1, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    Cube cube2 = new(new Vector3(secondCube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else if (secondCube.SecondCorner.X < cube.SecondCorner.X)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(secondCube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    Cube cube2 = new(new Vector3(secondCube.SecondCorner.X + 1, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else
                {
                    newCubes.Add(cube);
                }
            }
            cubes.Clear();
            cubes.AddRange(newCubes);
            newCubes.Clear();
            //Y split
            foreach (Cube cube in cubes)
            {
                if (secondCube.Position.Y > cube.Position.Y)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, secondCube.Position.Y - 1, cube.SecondCorner.Z));
                    Cube cube2 = new(new Vector3(cube.Position.X, secondCube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else if (secondCube.SecondCorner.Y < cube.SecondCorner.Y)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, secondCube.SecondCorner.Y, cube.SecondCorner.Z));
                    Cube cube2 = new(new Vector3(cube.Position.X, secondCube.SecondCorner.Y + 1, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else
                {
                    newCubes.Add(cube);
                }
            }
            cubes.Clear();
            cubes.AddRange(newCubes);
            newCubes.Clear();
            //Z split
            foreach (Cube cube in cubes)
            {
                if (secondCube.Position.Z > cube.Position.Z)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, secondCube.Position.Z - 1));
                    Cube cube2 = new(new Vector3(cube.Position.X, cube.Position.Y, secondCube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else if (secondCube.SecondCorner.Z < cube.SecondCorner.Z)
                {
                    Cube cube1 = new(new Vector3(cube.Position.X, cube.Position.Y, cube.Position.Z), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, secondCube.SecondCorner.Z));
                    Cube cube2 = new(new Vector3(cube.Position.X, cube.Position.Y, secondCube.SecondCorner.Z + 1), new Vector3(cube.SecondCorner.X, cube.SecondCorner.Y, cube.SecondCorner.Z));
                    newCubes.Add(cube1);
                    newCubes.Add(cube2);
                }
                else
                {
                    newCubes.Add(cube);
                }
            }
            cubes.Clear();
            cubes.AddRange(newCubes);
            newCubes.Clear();

            return cubes.ToArray();
        }
    }
}
