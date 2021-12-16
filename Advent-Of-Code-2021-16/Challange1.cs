namespace AdventOfCode.Day16
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
            //Just parse input string (in hex) into binary data
            string binary = "";
            foreach (char ch in input)
            {
                binary += Convert.ToString(Convert.ToInt32(ch.ToString(), 16), 2).PadLeft(4, '0');
            }

            //Parse a packet
            Packet p = Packet.ParsePacket(binary);

            //Ŕeturn Total Version of all packets
            return GetTotalVersion(p);
        }

        /// <summary>
        /// Loop through all subpackets and add their Version value to Version value of current packet
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        private static int GetTotalVersion(Packet packet)
        {
            int version = packet.Version;
            foreach (Packet subpacket in packet.Subpackets)
            {
                version += GetTotalVersion(subpacket);
            }
            return version;
        }
        
    }
}