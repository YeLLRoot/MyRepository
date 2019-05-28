using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Test2
{
    class LifeSign
    {

       

        private void XMLWrite(string FileName,LifeSign messageName,LifeSign messageTime,LifeSign source,LifeSign target)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>"
                +"\r\n"
                + "<Header>" + "\r\n" + "<MessageName>" + messageName + "</MessageName>" + "\r\n" + "<MessageTime>" + messageTime + "</MessageTime>" + "\r\n" + "</Header>"
                + "\r\n"
                + "<Body>" + "\r\n" + "<Source>" + source + "</Source>" + "\r\n" + "<Target>" + target + "</Target>" + "\r\n" + "</Body>"
                + "\r\n"
                +"</Envelope>");
            XmlDeclaration xmldecl;
            xmldecl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmldecl, root);
            doc.Save(FileName);
        }
    }
}
