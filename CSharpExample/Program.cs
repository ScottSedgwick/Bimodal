using System;

namespace CSharpExample
{
    class Program
    {
        static byte[] updateID(uint id)
        {
            int n;
            byte[] result = { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };  // Initialize with spaces
            result[0] = 7;
            for (n = 2; n < 9; n++)
            {
                result[n] = (byte)(0x30 + (id & 0x1f));
                id >>= 5;  //Right shifts bits of id by 5 and stores the result in id.
            }
            return result;
        }

        static void Main(string[] args)
        {
            uint hsh = 0x474E5253;
            byte[] result;
            uint ownId = 0x95C6DA80;

            Console.WriteLine($"Initial Hash : 0x{hsh}");
            Console.WriteLine($"Initial OwnID: 0x{ownId}");

            result = updateID(hsh ^ ownId);  // ^ is bitwise XOR

            Console.WriteLine("Updated ID:");

            int n;
            for (n = 0; n < 9; n++)
            {
                Console.Write($"0x{result[n]:x} ");
            }

            Console.WriteLine("\n\nPress Enter to continue.");
            Console.ReadLine();
        }
    }
}
