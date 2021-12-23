namespace AdventOfCode.Day22
{
    /// <summary>
    /// Keeps informations about one instruction
    /// </summary>
    public struct InstructionInfo
    {
        public bool Instruction = false; //Add = true, Remove = false
        public Cube Cube = Cube.Zero; //Cube target

        public InstructionInfo(bool instruction, Cube cube)
        {
            Instruction = instruction;
            Cube = cube;
        }
    }
}
