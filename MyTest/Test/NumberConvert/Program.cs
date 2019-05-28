using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Double test1 = 1000.52345;
            string s1=Convert.ToDouble(test1).ToString("f0");
            Console.WriteLine(s1);
            Console.ReadKey();
        }
    }
}
