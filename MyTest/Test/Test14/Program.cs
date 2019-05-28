using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test14
{
    class Program
    {
        static void Main(string[] args)
        {
            //int num = 0;
            //float num1 = 0.0001f;
            //Console.WriteLine(num1);

            //const float PRECISION = 0.000001f;
            //if (Math.Abs(num1) > PRECISION  )
            //    Console.WriteLine("Yes");
            //else
            //    Console.WriteLine("No");
            //if (num1>=-float.Epsilon&&num1<=float.Epsilon)
            //    Console.WriteLine(num1);

            //Console.WriteLine(float.Epsilon);
            //Console.ReadKey();

            int[] ints = { 5, 2, 0, 66, 4, 32, 7, 1 };

            //List<int> list = new List<int>();
            //foreach (int i in ints)
            //{
            //    list.Add(i);
            //}
            //list.Sort();
            //list.Reverse();

            //Console.WriteLine(string.Join(",", list));

            int[] intEvens = ints.Where(p => p % 2 == 0).ToArray();
            int[] intOdds = ints.Where(p => p % 2 != 0).ToArray();
            Console.WriteLine("偶数：" + string.Join(",", intEvens));
            Console.WriteLine("奇数：" + string.Join(",", intOdds));
            
            Console.ReadKey();
        }
    }
}
