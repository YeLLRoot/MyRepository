using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DWS.Class;

namespace AutoSize
{
    public partial class Form1 : Form
    {
        AutoSizeForm ASC_frmmain = new AutoSizeForm();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ASC_frmmain.controllInitializeSize(this);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            ASC_frmmain.controlAutoSize(this);
        }
    }
}
