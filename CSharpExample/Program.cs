using System;
using UpdateId;

namespace CSharpExample
{
    class Program
    {

        static void Main(string[] args)
        {
            byte[] result;
            //UInt32 ownId = 0x52618A12;
            UInt32 ownId = 0xE5E5A048;


            Console.WriteLine($"Initial OwnID: 0x{ownId:X}");

            result = BimodalId.Update(ownId);  // ^ is bitwise XOR

            Console.Write("Updated ID: 0x");

            int n;
            for (n = 0; n < 9; n++)
            {
                Console.Write($"{result[n]:X2}");
            }
            Console.WriteLine($"\nUpdated ID string: [{BimodalId.ToStr(result)}]");

            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }
    }
}
