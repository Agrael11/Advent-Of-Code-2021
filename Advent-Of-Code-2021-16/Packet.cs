namespace AdventOfCode.Day16
{
    /// <summary>
    /// Represents Single Packet
    /// </summary>
    class Packet
    {
        //Header + Length info
        public int Version { get; set; }
        public int TotalVersion
        {
            get
            {
                int version = Version;
                foreach (Packet packet in Subpackets)
                {
                    version += packet.TotalVersion;
                }
                return version;
            }
        }
        public int TypeID { get; set; }
        public int ContentLength { get; set; }
        public int HeaderLength { get; set; }
        public int Length { get { return ContentLength + HeaderLength; } }

        //Content
        public ulong Value { get; set; }
        public ulong TotalValue { 
            get
            {
                ulong value = Value;
                switch (TypeID)
                {
                    case 0:
                        foreach (Packet packet in Subpackets)
                        {
                            value += packet.TotalValue;
                        }
                        break;
                    case 1:
                        value = 1;
                        foreach (Packet packet in Subpackets)
                        {
                            value *= packet.TotalValue;
                        }
                        break;
                    case 2:
                        value = int.MaxValue;
                        foreach (Packet packet in Subpackets)
                        {
                            if (packet.TotalValue < value)
                                value = packet.TotalValue;
                        }
                        break;
                    case 3:
                        value = ulong.MinValue;
                        foreach (Packet packet in Subpackets)
                        {
                            if (packet.TotalValue > value)
                                value = packet.TotalValue;
                        }
                        break;
                    case 5:
                        value = (Subpackets[0].TotalValue > Subpackets[1].TotalValue) ? (ulong)1: (ulong)0;
                        break;
                    case 6:
                        value = (Subpackets[0].TotalValue < Subpackets[1].TotalValue) ? (ulong)1 : (ulong)0;
                        break;
                    case 7:
                        value = (Subpackets[0].TotalValue == Subpackets[1].TotalValue) ? (ulong)1 : (ulong)0;
                        break;
                }
                return value; 
            }
        }
        public List<Packet> Subpackets { get; }

        /// <summary>
        /// Creates packet from entered information
        /// </summary>
        /// <param name="version"></param>
        /// <param name="typeID"></param>
        /// <param name="contentLength"></param>
        /// <param name="headerLength"></param>
        /// <param name="value"></param>
        /// <param name="subpackets"></param>
        public Packet(int version, int typeID, int contentLength, int headerLength, ulong value, List<Packet> subpackets)
        {
            Version = version;
            TypeID = typeID;
            ContentLength = contentLength;
            HeaderLength = headerLength;
            Value = value;
            Subpackets = subpackets;
        }

        /// <summary>
        /// Parse string in binary into a packet
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static Packet ParsePacket(string inputData)
        {
            int version = Convert.ToInt32(inputData[..3], 2);
            int typeID = Convert.ToInt32(inputData[3..6], 2);
            int contentLength = 0;
            int headerLength = 6; //Default header length is 6
            ulong value = 0;
            List<Packet> packets = new();

            //If packet is just a plain value
            if (typeID == 4)
            {
                contentLength = 0;
                value = 0;
                int tempValue = 0;
                //Add last 4 bits of every 5 bits to a value, 1st bit is just information - if 1 = continue, if 0 = last value.
                do
                {
                    value <<= 4;
                    string hex = inputData.Substring(contentLength + headerLength, 5);
                    tempValue = Convert.ToInt32(hex, 2);
                    value += (ulong)Convert.ToInt64(hex[1..], 2);
                    contentLength += 5;
                } while (tempValue >> 4 != 0);
            }
            else //Packet contains subpackets
            {
                bool lengthInfo = inputData.Substring(headerLength, 1) == "1";
                if (lengthInfo) //Length Flag is 1, ContentLength contains amount of packets
                {
                    //Packets Count is 11 bits long after 1 bit flag
                    int packetsCount = Convert.ToInt32(inputData.Substring(headerLength + 1, 11), 2);
                    headerLength += 12;
                    string dataToParse = inputData[headerLength..];
                    contentLength = 0;
                    //Parse every subpacket according to amount of packets in ContentLength
                    for (int i = 0; i < packetsCount; i++)
                    {
                        Packet p = ParsePacket(dataToParse[contentLength..]);
                        contentLength += p.Length;
                        packets.Add(p);
                    }
                }
                else //Length Flag is 0, ContentLength contains actual length of content (wow)
                {
                    //Content Length is 15 bits long after 1 bit flag
                    contentLength = Convert.ToInt32(inputData.Substring(headerLength + 1, 15), 2);
                    headerLength += 16;
                    string dataToParse = inputData.Substring(headerLength, contentLength);
                    int position = 0;
                    //Parse every subpacket until we run out of content
                    while (position < contentLength)
                    {
                        Packet p = ParsePacket(dataToParse[position..]);
                        position += p.Length;
                        packets.Add(p);
                    }
                }
            }

            return new Packet(version, typeID, contentLength, headerLength, value, packets);
        }
    }
}
