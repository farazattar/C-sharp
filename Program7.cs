using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//This Program writes the desired byte of a binary file
namespace writebyte
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathSource = @"D:\Test\p40F.BIN";
            string pathNew = @"D:\Test\newfile3";
            try
            {
                using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fsSource.Length];
                    int totalbytes = (int)fsSource.Length;
                    string totalbytestring = Convert.ToString(totalbytes);
                    System.IO.File.WriteAllText(@"D:\Test\test.txt", totalbytestring);
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    Console.WriteLine("Please enter the Offset (Byte) :");
                    string offsetstring = Console.ReadLine();
                    int offset = Convert.ToInt32(offsetstring);
                    Console.WriteLine("Please enter the number of Bytes to read :");
                    string bytesreadstring = Console.ReadLine();
                    int bytesread = Convert.ToInt32(bytesreadstring);
                    using (FileStream fsNew = new FileStream(pathNew, FileMode.Create, FileAccess.Write))
                    {
                        fsNew.Write(bytes, offset, bytesread);
                    }
                }
            }
            catch
                (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }
        }
    }
}
 

        