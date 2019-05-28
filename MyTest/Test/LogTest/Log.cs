using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace DWS.Class
{
    class Log
    {  //每次质行都要去扫描磁盘文件
        public void WriteNormalLog(string msg,string lan = "zh-CN")
        {
            try
            {
                FileStream fs1;
                string nowYear, nowMonth, nowDay, DirPath, FilePath, BefYear, BefMonth, BefDay;

                DirPath = Application.StartupPath + @"\Log";//路径

                msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "   " + msg;

                nowYear = DateTime.Now.ToString("yyyy");
                nowMonth = DateTime.Now.ToString("MM");  
                nowDay = DateTime.Now.ToString("dd");
                BefYear = DateTime.Now.AddDays(-30).ToString("yyyy");
                BefMonth = DateTime.Now.AddDays(-30).ToString("MM");
                BefDay = DateTime.Now.AddDays(-30).ToString("dd");
                //删除上一月的日志
                if (File.Exists(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth + @"\" + BefDay + ".log"))
                {
                    File.Delete(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth + @"\" + BefDay + ".log");
                }
                if (Directory.Exists(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth))
                {
                    // if (Directory.GetDirectories(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth).Length == 0)
                     if (Directory.GetFiles(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth).Length == 0)
                    {
                        Directory.Delete(DirPath + @"\Normal" + @"\" + BefYear + @"\" + BefMonth, true);
                    }
                }
                if (Directory.Exists(DirPath + @"\Normal" + @"\" + BefYear))
                {
                    if (Directory.GetDirectories(DirPath + @"\Normal" + @"\" + BefYear).Length == 0)
                    {
                        Directory.Delete(DirPath + @"\Normal" + @"\" + BefYear, true);
                    }
                }

                //保存数据
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\Normal";
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\" + nowYear;
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\" + nowMonth;
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                FilePath = DirPath + @"\" + nowDay + ".log";
                if (!File.Exists(FilePath))
                {
                    fs1 = new FileStream(FilePath, FileMode.Create, FileAccess.Write,FileShare.ReadWrite);
                }
                else
                {
                    fs1 = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                }

                StreamWriter sw = new StreamWriter(fs1,Encoding.Default);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();

                fs1.Close();
                fs1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteNormalLog Err！" + ex.Message);
            }
        }

        public void WriteErrLog(string msg,string lan = "zh-CN")
        {
            try
            {
                FileStream fs1;
                string nowYear, nowMonth, nowDay, DirPath, FilePath, BefYear, BefMonth, BefDay;

                DirPath = Application.StartupPath + @"\Log";

                msg = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "   " + msg;

                nowYear = DateTime.Now.ToString("yyyy");
                nowMonth = DateTime.Now.ToString("MM");
                nowDay = DateTime.Now.ToString("dd");
                BefYear = DateTime.Now.AddDays(-30).ToString("yyyy");
                BefMonth = DateTime.Now.AddDays(-30).ToString("MM");
                BefDay = DateTime.Now.AddDays(-30).ToString("dd");

                if (File.Exists(DirPath + @"\Error" + @"\" + BefYear + @"\" + BefMonth + @"\" + BefDay + ".log"))
                {
                    File.Delete(DirPath + @"\Error" + @"\" + BefYear + @"\" + BefMonth + @"\" + BefDay + ".log");
                }
                if (Directory.Exists(DirPath + @"\Error" + @"\" + BefYear + @"\" + BefMonth))
                {
                    if (Directory.GetDirectories(DirPath + @"\Error" + @"\" + BefYear + @"\" + BefMonth).Length == 0)
                    {
                        Directory.Delete(DirPath + @"\Error" + @"\" + BefYear + @"\" + BefMonth, true);
                    }
                }
                if (Directory.Exists(DirPath + @"\Error" + @"\" + BefYear))//年
                {
                    if (Directory.GetDirectories(DirPath + @"\Error" + @"\" + BefYear).Length == 0)
                    {
                        Directory.Delete(DirPath + @"\Error" + @"\" + BefYear, true);
                    }
                }
                
                //保存数据
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\Error";
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\" + nowYear;
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                DirPath = DirPath + @"\" + nowMonth;
                if (!Directory.Exists(DirPath))
                {
                    Directory.CreateDirectory(DirPath);
                }

                FilePath = DirPath + @"\" + nowDay + ".log";
                if (!File.Exists(FilePath))
                {
                    fs1 = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                }
                else
                {
                    fs1 = new FileStream(FilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                }

                StreamWriter sw = new StreamWriter(fs1,Encoding.Default);
                sw.WriteLine(msg);
                sw.Flush();
                sw.Close();

                fs1.Close();
                fs1 = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("WriteErrLog Err！" + ex.Message);
            }
        }
    }
}
