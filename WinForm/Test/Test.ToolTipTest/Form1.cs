using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test.ToolTipTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tip_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl.Name == "txtUserName")
            {
                var tip = (ToolTip)sender;
                tip.ToolTipTitle = "信息提示";
                tip.ToolTipIcon = ToolTipIcon.Info;
            }
            else
            {
                var tip = (ToolTip)sender;
                tip.ToolTipTitle = "警告";
                tip.ToolTipIcon = ToolTipIcon.Warning;
            }
        }
    }
}
