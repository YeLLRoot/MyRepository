using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Test7
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(test1);
            th1.Start();
            Thread th2 = new Thread(test2);
            th2.Start();
            Console.ReadKey();
        }

        public static void test1()
        {
            for (int i = 0; i < 100000;i++ )
            {
                Console.Write(i);
            }
            Thread.Sleep(200);
        }
        public static void test2()
        {
            for (int i = 10; i < 200000; i++)
            {
                Console.Write(i);
            }
        }
    }
}
