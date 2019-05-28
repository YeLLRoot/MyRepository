using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test11
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dt = Convert.ToDateTime(str);
            Console.WriteLine(dt);
            Console.ReadKey();
        }
    }
}
