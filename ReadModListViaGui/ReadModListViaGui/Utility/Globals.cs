using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModListViaGui.Utility
{
    static class Globals
    {
        public const int ModIndexStart = 84;
        public static string Unit1DataBase = "[ModList].[dbo].[Unit1]";
        public static string Unit2DataBase = "[ModList].[dbo].[Unit2]";
        public static string Unit3DataBase = "[ModList].[dbo].[Unit3]";
        public static string Unit4DataBase = "[ModList].[dbo].[Unit4]";
        public static string DcsTimeZone = "Central Europe Standard Time";
        public static string ConnectionString = "Data Source=DCS34-PC\\DCS34;Initial Catalog=ModList;Integrated Security=True";
    }
}
