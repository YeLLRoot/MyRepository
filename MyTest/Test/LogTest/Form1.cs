using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DWS.Class;
using System.Threading;

namespace LogTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Log log = new Log();
        private void button1_Click(object sender, EventArgs e)
        {
            log.WriteNormalLog("Normal Log!");
            MessageBox.Show("成功！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.WriteErrLog("Error Log!");
            MessageBox.Show("成功！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //跨线程访问控件测试
            Thread th = new Thread(new ParameterizedThreadStart(Change));
            th.IsBackground = true;
            th.Start("Hello");            
        }
        delegate void Changes(object msg);
        private void Change(object msg)
        {
            //普通委托
            //if (button1.InvokeRequired)
            //{
            //    Changes change = new Changes(Change);
            //    button1.Invoke(change, new object[] { msg });
            //}
            //else
            //{
            //    button1.Text = (string)msg;
            //} 
           
            //匿名委托
            if (button1.InvokeRequired)
            {
                Changes change = delegate(object str)
                {
                    button1.Text = (string)msg;
                };
                button1.Invoke(change, new object[] { msg });
            }
            else 
            {
                button1.Text = (string)msg;
            }
        }
    }
}
