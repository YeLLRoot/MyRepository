using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DialogTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //文件对话框
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;
            file.Title = "请选择文件";
            file.Filter = "所有文件(*.png;*.jpg;*.bmp)|*.jpg;*.png";
            if (file.ShowDialog()==DialogResult.OK)
            {   
                this.textBox1.Text = file.FileName;
            }
            
            //文件夹对话框
            //FolderBrowserDialog path = new FolderBrowserDialog();
            //path.ShowDialog();
            //this.textBox1.Text = path.SelectedPath;
        }
    }
}
