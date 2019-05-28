using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test8
{
    class Program
    {
        public delegate void Test();
        static void Main(string[] args)
        {
            Test test = new Test(Test1.test1);
            test += Test1.test2;
            test();
            Console.ReadKey();
        }
    }
    public class Test1
    {
        public static void test1()
        {
            Console.WriteLine("test1");
        }

        public static void test2()
        {
            Console.WriteLine("test2");
        }
    }
}
