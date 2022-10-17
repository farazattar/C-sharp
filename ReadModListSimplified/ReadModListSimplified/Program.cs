using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace ReadModList
{
    struct ModIndexContent
    {
        public int ModPrefix;
        public int ModNum;
        public int ModTav;
        public int WriteTime;
        public int MSecWriteTime;
        public int Zero1;
        public int Zero2;
        public int Zero3;
        public int Zero4;
        public int StartTime;
        public int MSecStartTime;
        public int EndTime;
        public int MSecEndTime;
        public int StartTime2;
        public int MSecStartTime2;
        public int EndTime2;
        public int MSecEndTime2;
        public int Frei;
        public int Frei2;
        public int Zero5;
        public int Zero6;
    };
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"D:\g_in_pda_unit3";
            int ModIndexStart = 84;
//            int[] BinaryStream = null;
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("MOD List doesn't exist!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            using (FileStream filestream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                filestream.Seek(ModIndexStart, SeekOrigin.Begin);
                ModIndexContent ModContent;
                int ModIndexLenght = Marshal.SizeOf(typeof(ModIndexContent));
                byte[] ReadBuffer = new byte[ModIndexLenght];
                BinaryReader binaryreader = new BinaryReader(filestream);
                for (int i = 0; i < binaryreader.BaseStream.Length; i+=ModIndexStart)
                {
                    ReadBuffer = binaryreader.ReadBytes(ModIndexLenght);
                    GCHandle Handle = GCHandle.Alloc(ReadBuffer, GCHandleType.Pinned);
                    ModContent = (ModIndexContent)Marshal.PtrToStructure(
                    Handle.AddrOfPinnedObject(),
                    typeof(ModIndexContent));
                    Handle.Free();
                    Console.WriteLine(ModContent.ModPrefix);
                    Console.WriteLine(ModContent.ModNum);
                    Console.WriteLine(ModContent.ModTav);
                    Console.WriteLine(ModContent.StartTime);
                    Console.WriteLine(ModContent.EndTime);
                }
            }
        }
    }
}
