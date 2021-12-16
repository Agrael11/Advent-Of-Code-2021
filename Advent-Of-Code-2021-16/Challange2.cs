namespace AdventOfCode.Day16
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
        public static ulong DoChallange(string input)
        {
            //Just parse input string (in hex) into binary data
            string binary = "";
            foreach (char ch in input)
            {
                binary += Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0');
            }

            //Parse a packet
            Packet p = Packet.ParsePacket(binary);

            //Return total value of packet
            return p.TotalValue;
        }
    }
}