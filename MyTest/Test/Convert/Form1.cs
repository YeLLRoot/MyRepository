using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Convert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "0x"+textBox1.Text.Trim();
            int num = System.Convert.ToInt32(str1,16);
            this.textBox2.Text = num.ToString();
        }
    }
}
