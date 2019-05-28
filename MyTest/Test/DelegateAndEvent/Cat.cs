using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateAndEvent
{
    public class Cat
    {
        public delegate void MeowHandler(object sender, EventArgs e);
        public event MeowHandler Meow;

        protected virtual void OnMeow(EventArgs e)
        {
            MeowHandler temp = Meow;
            if (temp!=null)
            {
                temp(this,e);
            }
        }

        public void StartMeow()
        {
            EventArgs e = new EventArgs();
            Console.WriteLine("Cat start meow....");
            OnMeow(e);
        }
    }
}
