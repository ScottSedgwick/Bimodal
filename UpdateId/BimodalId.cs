using System;

namespace UpdateId
{
    public class BimodalId
    {
        private static UInt32 ReverseBytes(UInt32 value)
        {
            return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 |
                   (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
        }

        public static byte[] Update(UInt32 ownId)
        {
            UInt32 hsh = 0x474E5253;
            UInt32 revOwnId = ReverseBytes(ownId);
            uint id = hsh ^ revOwnId;
            int n;
            byte[] result = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };  // Initialize with spaces
            result[0] = (byte)7;
            for (n = 2; n < 9; n++)
            {
                result[n] = (byte)(0x30 + (id & 0x1f));
                id >>= 5;  //Right shifts bits of id by 5 and stores the result in id.
            }
            return result;
        }

        public static string ToStr(byte[] id)
        {
            string s = "";
            for (int n = 2; n < 9; n++)
            {
                s += Convert.ToChar(id[n]);
            }
            return s;
        }
    }
}
