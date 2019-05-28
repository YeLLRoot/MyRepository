using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "{  \"message\" : \"501-请求的服务异常！\",  \"code\" : 500,  \"warn\" : false,  \"succeed\" : false,  \"messageCode\" : 501}";
            string str1 = str.Replace(" ","");
            string str2 = "{ \r\n \"message\" : \"501-请求的服务异常！\",\r\n  \"code\" : 500, \r\n  \"warn\" : false,\r\n  \"succeed\" : false,\r\n  \"messageCode\" : 501 \r\n}";
            string str3 = str2.Replace(" ","").Replace("\r\n","");
            Console.WriteLine(str);
            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
            Console.ReadKey();
        }
    }
}
