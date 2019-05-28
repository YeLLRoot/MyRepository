using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using System.Drawing;

namespace Test1
{
    class Program
    {
        public struct Package
        {
            public int businessType;
            public int operateType;
            public string data;
        }
        public struct Data 
        {
            public int OperType;
            public PackageInfo[] OperBody;
        }
        public struct PackageInfo
        {
            public string packageCode;                      //包裹号
            public string machineCode;                      //设备机器码
            public float pWeight;                           //重量（kg）
            public float pLenght;                           //长度
            public float pWidth;                            //宽度
            public float pHigh;                             //高度
            public float volume;                            //体积
            public int opeUserId;                           //操作人Id
            public string opeUserName;                      //操作人姓名
            public string opeSiteId;                           //所属场地id
            public string opeSiteName;                      //所属场地名称
            public string opeTime;                          //时间
            public Image imagePath;
        }

        public struct SendData
        {
            public string content;
            public string functionCode;
            public string sysCode;
            public string warehouseId;
        }

        public struct Content
        {
            public long editTime;
            public string editWho;
            public int id;
            public string warehouseId;
            public string waybillNo;
            public string weight;
        }
        private static void Main(string[] args)
        {
            string str = test();
            Console.WriteLine(str);
            Console.ReadKey();
        }
        private static string test()
        {
            Package p = new Package();
            Data data = new Data();
            PackageInfo pi = new PackageInfo();
            p.businessType = 1001;
            p.operateType = 100102;
            data.OperType = 1;
            pi.packageCode = "VC46734240711-1-1";
            pi.machineCode ="JD_001";
            pi.pWeight = float.Parse((1000 / 100).ToString("1.51"));
            pi.pLenght = float.Parse((1000 / 100).ToString("36.06"));
            pi.pWidth = float.Parse((1000 / 100).ToString("22.06"));
            pi.pHigh = float.Parse((1000 / 100).ToString("13.22"));
            pi.volume = float.Parse((1000000000 / 1000000).ToString("10514038"));
            pi.opeUserId = Convert.ToInt32(164162);
            pi.opeUserName = "江峰";
            pi.opeSiteId = "706634";
            pi.opeSiteName = "泉州外单分拣中心";
            pi.opeTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            data.OperBody=new PackageInfo[1];
            data.OperBody[0] = pi;
            p.data = GetRequestJsonString(data);
           
            string str = EncodeSendStr(p);
            //string str = GetRequestJsonString(p).ToString();
            return str;
        }
        private static string test1()
        {
            demo d= new demo();
            d.Name = "test";
            d.Value= "this is a test";
            string str = GetRequestJsonString(d);
            return str;
        }

        private static string test2()
        {
            SendData data = new SendData();
            Content content = new Content();
            content.editTime = 1536020796517;
            content.editWho = "639013";
            content.id = 1;
            content.warehouseId = "SF-CONSO";
            content.waybillNo = "126921608733,126921608734,126927608735,126921608736";
            content.weight = "1.5";
            data.content = GetRequestJsonString(content);
            data.functionCode = "ASN_WEIGHT_UPLOAD";
            data.sysCode = "206";
            data.warehouseId = "SF-CONSO";
            string str = GetRequestJsonString(data);
            return str;
        }
        private static string GetRequestJsonString(Object request)
        {
            //JavaScriptSerializer js = new JavaScriptSerializer();//, Formatting.Indented
            return JsonConvert.SerializeObject(request);
            //return new JavaScriptSerializer().Serialize(request);
        }
        private static string EncodeSendStr(object obj)
        {
            try
            {
                //string strData = "";
                string data = GetRequestJsonString(obj).ToString();
                //string operBody;
                //string str,str1;
                //operBody = GetRequestJsonString(pi);
                //str = "{";
                //str += "\"operType\":1,";
                //str += "\"operBody\":";
                //str += "[";
                //str += operBody;
                //str += "]";
                //str += "}";
                //str1 = GetRequestJsonString(str);
                //strData += "{";
                //strData += "\"businessType\":1001,";
                //strData += "\"operateType\":100102,";
                //strData += "\"data\":";
                //strData += "\"";
                //strData += "{";
                //strData += "\"operType\":1,";
                //strData += "\"operBody\":";
                //strData += "[";
                //strData += operBody;
                //strData += "]";
                //strData += "}";
                //strData += data;
                //strData += "\"";
                //strData += "}";
                return data;
            }
            catch
            {
               
            }
            return null;
        }

        class demo
        {
            private string name;

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            private string value;

            public string Value
            {
                get { return this.value; }
                set { this.value = value; }
            }
        }
    }
}