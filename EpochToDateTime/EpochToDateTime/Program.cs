using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace EpochToDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int UnixTime = Convert.ToInt32(args[0]);
            DateTimeOffset UtcDateTime = DateTimeOffset.FromUnixTimeSeconds(UnixTime);
            DateTime DtUtcDateTime = UtcDateTime.DateTime;
            TimeZoneInfo TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            DateTime LocalDateTime = TimeZoneInfo.ConvertTimeFromUtc(DtUtcDateTime, TimeZone);
            Console.WriteLine("UTC Date Time is {0}.", UtcDateTime);
            Console.WriteLine("Local Date Time (with Time Zone) is {0}.", LocalDateTime);
        }
    }
}
