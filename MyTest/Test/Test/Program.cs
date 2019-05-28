using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Test
{
    class Program
    {
        private static string scheme = "http";
        private static string server = "dmsvertest.360buy.com";
        private static string port = "80";
        private static string resource = "/services/deviceCommend/execute";
        private static string method = "POST";
        private static string contentType = "application/json";

        private static string registerNo = "QZWD-HZXL-JD";
        private static string WRAP = "\n";
        private static string HMACMESSAGEKEY = "QL_DMS";
        private static string siteCode = "706634";
        private static string opCode = "packageWeightSquareInfo";
        private static string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


        static void Main(string[] args)
        {
            string json = "{\"businessType\":1001,\"operateType\":100102,\"data\":{\"operType\":1,\"operBody\":[{\"packageCode\":\"VC46185408894-1-1-\",\"machineCode\":\"\",\"pWeight\":1.36,\"pLength\":41.23,\"pWidth\":31.48,\"pHigh\":8.36,\"volume\":10848.98,\"opeUserId\":164162,\"opeUserName\":\"江峰\",\"opeSiteId\":706634,\"opeSiteName\":\"泉州外单分拣中心\",\"opeTime\":\"2018-08-09 20:14:22\"}]}}";
            string text = GetAuthorization(json);
            Console.WriteLine(json);
            Console.WriteLine(text);
            Console.ReadKey();
        }


        private static string GetAuthorization(string json)
        {
            byte[] key = System.Text.Encoding.UTF8.GetBytes(registerNo);
            string messageStr = HMACMESSAGEKEY + WRAP
                                + scheme + WRAP
                                + server + ":" + port + WRAP
                                + method + WRAP
                                + resource + WRAP
                                + contentType + WRAP
                                + siteCode + WRAP
                                + registerNo + WRAP
                                + opCode + WRAP
                                + date + WRAP
                                + json + WRAP;
            Console.WriteLine(messageStr);
            HMACSHA512 hmacsha512 = new HMACSHA512(key);
            byte[] hmacBytes = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(messageStr));
            return Convert.ToBase64String(hmacBytes);
        }
    }
}
