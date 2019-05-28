using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test9
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(1970,1,1,0,0,0,0);
            Console.WriteLine(dt);
            DateTime dtPackage;
            UInt64 DiffDT = 8 * 60 * 60 * 1000;
            dtPackage = dt.AddMilliseconds(DiffDT);
            //dtPackage = DateTime.UtcNow;//2018-09-19 01:08:09
            Console.WriteLine(dtPackage);

            string timeStamp = GetTimeStamp();
            Console.WriteLine(GetTimeStamp());

            DateTime currentDate = GetTime(timeStamp);
            string datestring = currentDate.ToString("yyyy-MM-dd HH:mm:ss fff");
            Console.WriteLine(datestring);
            Console.ReadKey();
        }

        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1,0,0,0));

            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}
