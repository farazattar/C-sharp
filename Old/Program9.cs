using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication9
{
    public static class program
    {
        static void Main(string[] args)
        {
            byte myByte = 0x33;
            Console.WriteLine("My Byte is {0}", myByte);
            string myByteString = Convert.ToString(myByte, 2);
            Console.WriteLine("My Byte string is {0}", myByteString);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
