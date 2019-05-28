using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace Test5
{
    public partial class Form1 : Form
    {
        public struct Header
        {
            public string MessageName;
            public string MessageTime;
        }
        public struct Body
        {
            public string Source;
            public string Target;
        }
        public struct Envelops
        {
            public Header Header;
            public Body Body;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Header header = new Header();
            header.MessageName = "LifeSignRequest";
            header.MessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Body body = new Body();
            body.Source = "CRCS";
            body.Target = "DVIRS";
            Envelops envelop = new Envelops();
            envelop.Header = header;
            envelop.Body = body;

            Type type = typeof(Envelops);
            string str = Serializer(type, envelop);
            text.Text = str;
        }
        public static string Serializer(Type type, object obj)
        {
            using (MemoryStream Stream = new MemoryStream())
            {
                //MemoryStream Stream = new MemoryStream();
                using (StreamWriter textWriter = new StreamWriter(Stream, Encoding.GetEncoding("utf-8")))
                {
                    //创建序列化对象  
                    XmlSerializer xml = new XmlSerializer(type);
                    try
                    {
                        //序列化对象  
                        xml.Serialize(textWriter, obj);
                    }
                    catch (InvalidOperationException)
                    {
                        throw;
                    }
                    Stream.Position = 0;
                    StreamReader sr = new StreamReader(Stream);
                    string str = sr.ReadToEnd();
                    sr.Dispose();
                    return str;
                }
            }
        }
    }
}
