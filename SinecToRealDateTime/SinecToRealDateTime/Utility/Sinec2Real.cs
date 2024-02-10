using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinecToRealDateTime.Utility
{
    class Sinec2Real
    {
        public static DateTime ConvertSinecToDateTime(string SinecDateHex, string SinecTimeHex)
        {
            // Convert hex to uint
            uint SinecDate = Convert.ToUInt32(SinecDateHex, 16);
            uint SinecTime = Convert.ToUInt32(SinecTimeHex, 16);
            
            // SINEC time starts from January 1, 1984
            DateTime BaseDate = new DateTime(1984, 1, 1);

            // Convert days to seconds
            uint SinecDaysToSeconds = SinecDate * 24 * 3600;
            uint SinecTimeToSeconds = SinecTime / 1000;
            uint SinecSeconds = SinecDaysToSeconds + SinecTimeToSeconds;
            
            // Convert seconds to TimeSpan
            TimeSpan TotalTimeSpan = TimeSpan.FromSeconds(SinecSeconds);

            // Add the TimeSpan to the base date
            DateTime RealDateTime = BaseDate.Add(TotalTimeSpan);

            return RealDateTime;
        }
    }
}
