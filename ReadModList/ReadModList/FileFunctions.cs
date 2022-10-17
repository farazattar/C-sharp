using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ReadModList
{
    class FileFunctions
    {
        public static void CheckInputFile(string Inputfile)
        {
            if (!File.Exists(Inputfile))
            {
                Console.WriteLine("MOD List doesn't exist!");
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        public static void CreateOutputfile(string OutputFile)
        {
            if (File.Exists(OutputFile))
            {
                File.Delete(OutputFile);
            }
        }
        public void WriteToOutputFile(int ModNum, int ModTav, DateTime StartTime, DateTime EndTime, DateTime WriteTime)
        {
            using(StreamWriter FileWriter = File.AppendText(Globals.OutputFilePath))
            {
                FileWriter.WriteLine("Mod: {0}\t"+
                                     "Tav: {1}\t"+
                                     "From: {2}\t"+
                                     "To: {3}\t"+
                                     "Written at: {4}\t",                                            
                                     ModNum,
                                     ModTav,
                                     StartTime,
                                     EndTime,
                                     WriteTime);
            }
        }
    }
}
