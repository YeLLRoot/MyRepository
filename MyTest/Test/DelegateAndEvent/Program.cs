using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateAndEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat();
            Mouse mouse = new Mouse(cat);
            //mouse.Unregister(cat);
            cat.StartMeow();
            Console.ReadKey();
        }
    }
}
