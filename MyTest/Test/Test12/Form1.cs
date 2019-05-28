using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filepath;
        string Backupfilepath;
        string[] strfilename;
        uint imgindex;



        private void RefreshPicFile()
        {
            try
            {
                imgindex = 0;

               
                this.pictureBox1.Image = null;
                
                if (Directory.Exists(filepath))
                {
                    strfilename = Directory.GetFiles(filepath);
                    string filename = Path.GetFileName(strfilename[imgindex]);
                    if (strfilename.Length > 0)
                    {
                        FileStream fs = new FileStream(strfilename[imgindex], FileMode.Open, FileAccess.Read);
                        this.pictureBox1.Image = System.Drawing.Image.FromStream(fs);
                        fs.Close();
                        fs.Dispose();
                        tbxFilename.Text = filename;

                        button1.Enabled = false;

                        if (strfilename.Length > 1)
                        {
                            button2.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filepath = Application.StartupPath + @"\Image";
            RefreshPicFile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(Application.StartupPath + @"\Image\" + tbxFilename.Text);
                this.pictureBox1.Refresh();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            imgindex -= 1;
            string filename = Path.GetFileName(strfilename[imgindex]);
            tbxFilename.Text = filename;
            FileStream fs = new FileStream(strfilename[imgindex], FileMode.Open, FileAccess.Read);
            this.pictureBox1.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();
            fs.Dispose();
            if (imgindex == 0)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imgindex += 1;
            if (imgindex >= strfilename.Length)
            {
                imgindex = 0;
            }
            string filename = Path.GetFileName(strfilename[imgindex]);
            tbxFilename.Text = filename;
            FileStream fs = new FileStream(strfilename[imgindex], FileMode.Open, FileAccess.Read);
            this.pictureBox1.Image = System.Drawing.Image.FromStream(fs);
            fs.Close();
            fs.Dispose();
            if(imgindex>0)
            {
                button1.Enabled = true;
            }
        }
    }
}
