using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace ReadModListAlternative
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
    class MemoryReader : BinaryReader
    {
        public MemoryReader(byte[] buffer)
            : base(new MemoryStream(buffer))
        {
        }
        public T ReadStruct<T>()
        {
            int ByteLenght = Marshal.SizeOf(typeof(T));
            var bytes = ReadBytes(ByteLenght);
            GCHandle pinned = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stt = (T)Marshal.PtrToStructure(
                pinned.AddrOfPinnedObject(),
                typeof(T));
            pinned.Free();
            return stt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string FilePath = @"D:\g_in_pda_unit3";
            int ModIndexStart = 84;
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
                using (BinaryReader binaryreader = new BinaryReader(filestream))
                {
                    for (int i = 0; i < binaryreader.BaseStream.Length; i++)
                    {
                        int ModIndexLenght = Marshal.SizeOf(typeof(ModIndexContent));
                        var buffer = new byte[ModIndexLenght];
                        var mem = new MemoryReader(buffer);
                        var ModContent = mem.ReadStruct<ModIndexContent>();
                        Console.WriteLine(ModContent.ModNum);
                        Console.WriteLine(ModContent.ModTav);
                    }
                }
            }
        }
    }
}
