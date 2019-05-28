using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Log4NetTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("MyLog");
            if (log.IsDebugEnabled)
            {
                log.Debug("Hello Log4Net!");
            }
        }
    }
}
