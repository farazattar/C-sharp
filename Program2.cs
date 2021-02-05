using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BinaryRW
{
    class Program
    {
        static void Main(string[] args)
        {
            string fpath = @"D:\Test\Test";
            if (File.Exists(fpath))
            {
                File.Delete(fpath);
            }
            using (BinaryWriter bw = new BinaryWriter(File.Open(fpath, FileMode.Create)))
            {
                bw.Write((byte)0x01);
            }
            using (BinaryReader br = new BinaryReader(File.Open(fpath, FileMode.Open)))
            {
                Console.WriteLine(br.ReadByte());
             }
            Console.ReadLine();
        }
    }
}
