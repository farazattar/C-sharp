using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModListViaGui.Utility
{
    static class ExceptionHandling
    {
        public static void ExecptionOutput(Exception e)
        {
            Console.WriteLine("\n***Error Occured!***");
            Console.WriteLine("Method: {0}", e.TargetSite);
            Console.WriteLine("Message: {0}", e.Message);
            Console.WriteLine("Source: {0}", e.Source);
        }
    }
}
