using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace ReadModListWithFile
{
    class StructReader
    {
        public static void ReadStruct(string FilePath, int Offset)
        {   
            using (FileStream filestream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
            {
                filestream.Seek(Offset, SeekOrigin.Begin);
                ModIndexContent ModContent;
                int ModIndexLenght = Marshal.SizeOf(typeof(ModIndexContent));
                byte[] ReadBuffer = new byte[ModIndexLenght];
                using (BinaryReader binaryreader = new BinaryReader(filestream))
                {
                    for (int i = 0; i < (binaryreader.BaseStream.Length - Offset); i += Offset)
                    {
                        ReadBuffer = binaryreader.ReadBytes(ModIndexLenght);
                        GCHandle Handle = GCHandle.Alloc(ReadBuffer, GCHandleType.Pinned);
                        ModContent = (ModIndexContent)Marshal.PtrToStructure(
                        Handle.AddrOfPinnedObject(),
                        typeof(ModIndexContent));
                        Handle.Free();
                        FileFunctions File = new FileFunctions();
                        File.WriteToOutputFile(ModContent.ModNum,
                                         ModContent.ModTav,
                                         UnixTimeToDataTimeConverter.EpochToDateConverter(ModContent.StartTime, Globals.DcsTimeZone),
                                         UnixTimeToDataTimeConverter.EpochToDateConverter(ModContent.EndTime, Globals.DcsTimeZone),
                                         UnixTimeToDataTimeConverter.EpochToDateConverter(ModContent.WriteTime, Globals.DcsTimeZone));
                    }
                }
            }
        }
    }
}
