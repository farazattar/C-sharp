using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication10
{
    class Program
    {
        static void Main(string[] args)
        {
//my hex number            
            Byte MyByte = 0x33;
            Console.WriteLine("This is My Byte : 0x{0:x2} ", MyByte);
//hex-to-(8bit)binary
            String MyByteString = Convert.ToString(MyByte, 2).PadLeft(8,'0');
            Console.WriteLine("This is My Byte String : {0} ", MyByteString);
//bit0
            bool bit0 = (MyByte & (1 << 0)) != 0;
            Console.WriteLine("The bit0 is : {0} ", bit0);
            int ibit0 = Convert.ToInt32(bit0);
            Console.WriteLine("The bit0 is : {0}" , ibit0); 
//bit1
            bool bit1 = (MyByte & (1 << 1)) != 0;
            Console.WriteLine("The bit1 is : {0} ", bit1);
            int ibit1 = Convert.ToInt32(bit1);
            Console.WriteLine("The bit1 is : {0}", ibit1); 
//bit2
            bool bit2 = (MyByte & (1 << 2)) != 0;
            Console.WriteLine("The bit2 is : {0} ", bit2);
            int ibit2 = Convert.ToInt32(bit2);
            Console.WriteLine("The bit2 is : {0}", ibit2);
//bit3
            bool bit3 = (MyByte & (1 << 3)) != 0;
            Console.WriteLine("The bit3 is : {0} ", bit3);
            int ibit3 = Convert.ToInt32(bit3);
            Console.WriteLine("The bit3 is : {0}", ibit3);
//bit4
            bool bit4 = (MyByte & (1 << 4)) != 0;
            Console.WriteLine("The bit4 is : {0} ", bit4);
            int ibit4 = Convert.ToInt32(bit4);
            Console.WriteLine("The bit4 is : {0}", ibit4);
//bit5
            bool bit5 = (MyByte & (1 << 5)) != 0;
            Console.WriteLine("The bit5 is : {0} ", bit5);
            int ibit5 = Convert.ToInt32(bit5);
            Console.WriteLine("The bit5 is : {0}", ibit5);
//bit6
            bool bit6 = (MyByte & (1 << 6)) != 0;
            Console.WriteLine("The bit6 is : {0} ", bit6);
            int ibit6 = Convert.ToInt32(bit6);
            Console.WriteLine("The bit6 is : {0}", ibit6);
//bit7
            bool bit7 = (MyByte & (1 << 7)) != 0;
            Console.WriteLine("The bit7 is : {0} ", bit7);
            int ibit7 = Convert.ToInt32(bit7);
            Console.WriteLine("The bit7 is : {0}", ibit7); 

            Console.WriteLine("Please press any key ...");
            Console.ReadKey();
        }
    }
}
