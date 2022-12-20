using System;
using System.IO;
// This program cuts the head of the binary file (Offset)
class Test
{
        public static void Main()
    {
        // Specify a file to read from and to create.
        string pathSource = @"D:\Test\p40F.BIN";
        string pathNew = @"D:\Test\newfile2";
        string offsetString;
        Console.WriteLine("Please enter the offset (Byte number) :");
        offsetString = Console.ReadLine();
        int offset = Convert.ToInt32(offsetString);
        try
        {

            using (FileStream fsSource = new FileStream(pathSource,
                FileMode.Open, FileAccess.Read))
            {

                // Read the source file into a byte array.
                byte[] bytes = new byte[fsSource.Length];
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
                numBytesToRead = bytes.Length - offset;

                // Write the byte array to the other FileStream.
                using (FileStream fsNew = new FileStream(pathNew,
                    FileMode.Create, FileAccess.Write))
                {
                    fsNew.Write(bytes, offset , numBytesToRead);
                }
            }
        }
        catch (FileNotFoundException ioEx)
        {
            Console.WriteLine(ioEx.Message);
        }
    }
}
