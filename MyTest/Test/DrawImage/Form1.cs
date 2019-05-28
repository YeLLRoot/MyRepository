using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace DrawImage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"D:\Image\test.jpg", FileMode.Open, FileAccess.Read);
            Image img = Image.FromStream(fs);
            fs.Close();
            fs.Dispose();
            fs = null;
            Bitmap tableChartImage = new Bitmap(img.Width,img.Height);
            Graphics graphics = Graphics.FromImage(tableChartImage);
            graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            Font font = new Font("微软雅黑", 20, FontStyle.Regular);
            string str = "Hello,World!";
            graphics.DrawString(str, font, new SolidBrush(Color.Red), 5, 130);
            img = tableChartImage;
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

            string nowMonth, nowDay, nowHours, nowYear;

            nowYear = DateTime.Now.ToString("yyyy");
            nowMonth = DateTime.Now.ToString("yyyyMM");
            nowDay = DateTime.Now.ToString("yyyyMMdd");
            nowHours = DateTime.Now.ToString("yyyyMMddHH");
            string DirPath;
            string path = @"D:\Image";
            if (System.IO.Directory.Exists(path))
            {
                if (img!= null)
                {
                    DirPath = path + @"\" + nowYear;
                    if (!Directory.Exists(DirPath))
                    {
                        Directory.CreateDirectory(DirPath);
                    }

                    DirPath = DirPath + @"\" + nowMonth;
                    if (!Directory.Exists(DirPath))
                    {
                        Directory.CreateDirectory(DirPath);
                    }

                    DirPath = DirPath + @"\" + nowDay;
                    if (!Directory.Exists(DirPath))
                    {
                        Directory.CreateDirectory(DirPath);
                    }

                    DirPath = DirPath + @"\" + nowHours;
                    if (!Directory.Exists(DirPath))
                    {
                        Directory.CreateDirectory(DirPath);
                    }
                    string PicName;
                    PicName = StrPictureName("123456");
                    if (!string.IsNullOrEmpty(PicName))
                    {
                        path = DirPath + @"\" + PicName;
                        img.Save(path, ImageFormat.Jpeg);
                    }
                    
                }
            }

            //img.Save(@"D:\Image" + filename, ImageFormat.Jpeg);
            this.pictureBox1.Load(path);
        }
        private string StrPictureName(string bcd)
        {
            try
            {
                string PictureName;
                PictureName = "";

                PictureName += DateTime.Now.ToString("yyyyMMddHHmmss");
                PictureName += "_" + bcd;
                PictureName += ".jpg";
                return PictureName;
            }
            catch (Exception ex)
            {
               
                return "";
            }
        }
    }
}
