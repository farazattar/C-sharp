﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace ReadModListWithExceptionHandling
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
            FileFunctions.CheckInputFile(Globals.InputFilePath);
            FileFunctions.CreateOutputfile(Globals.OutputFilePath);
            try
            {
                DataBaseFunctions DbFunctions = new DataBaseFunctions();
                DbFunctions.ConnectToDb(Globals.ConnectionString);
                DbFunctions.TruncateDb(Globals.UnitDataBase);
                DbFunctions.DisconnectFromDb();
            }
            catch (Exception e)
            {
                ExceptionHandling.ExecptionOutput(e);
            }
            try
            {
                StructReader.ReadStruct(Globals.InputFilePath, Globals.ModIndexStart);
            }
            catch (Exception e)
            {
                ExceptionHandling.ExecptionOutput(e);
            }
        }
    }
}
