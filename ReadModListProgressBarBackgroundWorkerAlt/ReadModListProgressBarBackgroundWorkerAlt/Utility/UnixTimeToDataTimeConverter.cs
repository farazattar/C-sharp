using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModListProgressBarBackgroundWorkerAlt.Utility
{
    class UnixTimeToDataTimeConverter
    {
        public static DateTime EpochToDateConverter(int UnixTime, string CustomTimeZone)
        {
            DateTimeOffset UtcDateTime = DateTimeOffset.FromUnixTimeSeconds(UnixTime);
            DateTime DtUtcDateTime = UtcDateTime.DateTime;
            TimeZoneInfo TimeZone = TimeZoneInfo.FindSystemTimeZoneById(CustomTimeZone);
            DateTime LocalDateTime = TimeZoneInfo.ConvertTimeFromUtc(DtUtcDateTime, TimeZone);
            return LocalDateTime;
        }
    }
}