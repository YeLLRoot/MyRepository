using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Test6
{
    public partial class Form1 : Form
    {
        public struct Json
        {
            public int code;
            public int messageCode;
            public string message;
            public Data data;
        }
        public struct Data
        {
            public string packageCode;
            public string packageImgStr;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string jsonStr = new StreamReader("data.json").ReadToEnd();
            string jsonStr = @"{""message"":""501-请求的服务异常！"",""code"":500,""warn"":false,""succeed"":false,""messageCode"":501}";
            JsonReader reader = new JsonTextReader(new StringReader(jsonStr));
            Json json = (Json)reader.Value;
            textBox1.Text = json.code + json.message;
        }
    }
}
