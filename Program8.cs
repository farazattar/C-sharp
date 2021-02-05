/*
Simplified BSD License

Copyright 2017 Derek Will

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
in the documentation and/or other materials provided with the distribution.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
OF SUCH DAMAGE.
*/
using System;

namespace ByteExtensionMethods
{
    public static class ByteExtensions
    {
        public static bool IsBitSet(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (b & (1 << pos)) != 0;
        }

        public static byte SetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (byte)(b | (1 << pos));
        }

        public static byte UnsetBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (byte)(b & ~(1 << pos));
        }

        public static byte ToggleBit(this byte b, int pos)
        {
            if (pos < 0 || pos > 7)
                throw new ArgumentOutOfRangeException("pos", "Index must be in the range of 0-7.");

            return (byte)(b ^ (1 << pos));
        }

        public static string ToBinaryString(this byte b)
        {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }
    }
    class Program
    {
        static void Main()
        {
            byte myByte = 0x33;

            Console.WriteLine("*** Byte Extension Methods ***");
            Console.WriteLine("Initial Value: {0}", PrintInfo(myByte));
            Console.WriteLine(string.Empty);

            Console.WriteLine("----- Testing Bit Status Check Methods -----");
            Console.WriteLine("Is Bit 3 set: {0}", myByte.IsBitSet(3));
            Console.WriteLine("Is Bit 6 set: {0}", myByte.IsBitSet(6));

            Console.WriteLine(string.Empty);
            Console.WriteLine("----- Testing Bit Manipulation Methods -----");
            Console.WriteLine("Initial For Reference: {0}", PrintInfo(myByte));

            myByte = myByte.SetBit(4);
            Console.WriteLine("After Setting Bit 4  : {0}", PrintInfo(myByte));

            myByte = myByte.UnsetBit(5);
            Console.WriteLine("After Unsetting Bit 5: {0}", PrintInfo(myByte));

            myByte = myByte.ToggleBit(0);
            Console.WriteLine("After Toggling Bit 0 : {0}", PrintInfo(myByte));

            myByte = myByte.ToggleBit(4);
            Console.WriteLine("After Toggling Bit 4 : {0}", PrintInfo(myByte));

            Console.WriteLine(string.Empty);
            Console.WriteLine("----- Testing Exception Throwing -----");
            try
            {
                myByte.IsBitSet(-3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Caught {0}: {1}", ex.GetType().Name, ex.Message);
            }

            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static string PrintInfo(byte b)
        {
            return string.Format("Byte = {0:x2} | Binary String = {1}", b, b.ToBinaryString());
        }
    }
}
