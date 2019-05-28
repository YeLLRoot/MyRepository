using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateAndEvent
{
    public class Mouse
    {
        public Mouse(Cat cat)
        {
            cat.Meow += new Cat.MeowHandler(cat_Meow);
        }
        void cat_Meow(object sender,EventArgs e)
        {
            Console.WriteLine("Mouse start run...");
        }
        public void Unregister(Cat cat)
        {
            cat.Meow -= cat_Meow;
        }
        
    }
}
