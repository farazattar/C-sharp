using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace binaryreader
{
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"D:\g_in_pda_unit3";
            byte[] BinaryStream = null;
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("MOD List doesn't exist!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            using (FileStream filestream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryreader = new BinaryReader(filestream))
                {
                    BinaryStream = new byte[binaryreader.BaseStream.Length];
                    for (int i = 0; i < binaryreader.BaseStream.Length; i++)
                    {
                        BinaryStream[i] = binaryreader.ReadByte();
                        Console.WriteLine(BinaryStream[i]);
                    }
                }
            }
        }
    }
}
