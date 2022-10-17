using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModList
{
    static class Globals
    {
        public const int ModIndexStart = 84;
        public static string UnitDataBase = "[ModList].[dbo].[Unit3]";
        public static string InputFilePath = @"D:\g_in_pda";
        public static string OutputFilePath = @"D:\outputfile.txt";
        public static string DcsTimeZone = "Central Europe Standard Time";
        public static string ConnectionString = "Data Source=DCS34-PC\\DCS34;Initial Catalog=ModList;Integrated Security=True";
    }
}
