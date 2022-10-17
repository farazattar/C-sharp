using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModListWithUsing
{
    class UnixTimeToDataTimeConverter
    {
        public static DateTime EpochToDateConverter(int UnixTime)
        {
            DateTimeOffset UtcDateTime = DateTimeOffset.FromUnixTimeSeconds(UnixTime);
            DateTime DtUtcDateTime = UtcDateTime.DateTime;
            TimeZoneInfo TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            DateTime LocalDateTime = TimeZoneInfo.ConvertTimeFromUtc(DtUtcDateTime, TimeZone);
            return LocalDateTime;
        }
    }
}