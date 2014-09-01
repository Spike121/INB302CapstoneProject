using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecommenderAttacksAnalytics.Utility
{
    class Logger
    {

        public static void log(string str)
        {
            Console.Out.WriteLine(str);
        }

        public static void logWarning(string str)
        {
            
        }

        public static void logError(string str)
        {
            Console.Out.WriteLine("ERROR: " + str);
        }

    }
}
